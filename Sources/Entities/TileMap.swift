import Raylib

struct TileMap: Entity {
    private let model: TileMapModel
    private var loadedTextures: [Int: Texture2D] = [:]
    private var tileLayers: [TileLayer] = []
    private let scale: Float

    let renderLayer: RenderLayer = .tileMap

    init(model: TileMapModel, scale: Float = 4.0) {
        self.model = model
        self.scale = scale

        var extractedLayers: [TileLayer] = []

        for anyLayer in model.layers {
            if let tileLayer = anyLayer.layer as? TileLayer {
                extractedLayers.append(tileLayer)
            } else if let objectLayer = anyLayer.layer as? ObjectLayer {
                // TODO: Handle object layer
            }
        }
        self.tileLayers = extractedLayers
        self.loadTileSets()

    }

    mutating func update(inputState: InputState, deltaTime: Float) {
        // Do nothing.
    }

    func draw() {
        for layer in tileLayers {
            drawLayer(layer)
        }
    }

    private mutating func loadTileSets() {
        for tileset in model.tilesets {
            let texture = Raylib.loadTexture(tileset.source)
            loadedTextures[tileset.firstgid] = texture
        }
    }

    private func drawLayer(_ layer: TileLayer) {
        for y in 0..<layer.height {
            for x in 0..<layer.width {
                let index = y * layer.width + x
                let tileId = layer.data[index]

                if tileId == 0 { continue }

                if let (tileset, texture) = getTileSetForTileId(tileId) {
                    let localTileId = tileId - tileset.firstgid
                    drawTile(
                        texture: texture, localTileId: localTileId, x: x * model.tilewidth,
                        y: y * model.tileheight)
                }
            }
        }
    }

    private func getTileSetForTileId(_ tileId: Int) -> (TileSet, Texture2D)? {
        let sortedTileSets = model.tilesets.sorted { $0.firstgid > $1.firstgid }
        for tileset in sortedTileSets {
            if tileId >= tileset.firstgid {
                if let texture = loadedTextures[tileset.firstgid] {
                    return (tileset, texture)
                }
                break
            }
        }

        return nil
    }

    private func drawTile(texture: Texture2D, localTileId: Int, x: Int, y: Int) {
        let tws = model.tilewidth + 1
        let twh = model.tileheight + 1

        let tilesPerRow = (Int(texture.width) + 1) / tws
        let srcX = (localTileId % tilesPerRow) * tws
        let srcY = (localTileId / tilesPerRow) * twh

        let srcRect = Rectangle(
            x: Float(srcX),
            y: Float(srcY),
            width: Float(model.tilewidth),
            height: Float(model.tileheight)
        )

        let dstRect = Rectangle(
            x: Float(x) * scale,
            y: Float(y) * scale,
            width: Float(model.tilewidth) * scale,
            height: Float(model.tileheight) * scale
        )

        Raylib.drawTexturePro(texture, srcRect, dstRect, Vector2(x: 0, y: 0), 0.0, .white)
    }
}

import Raylib

enum TiledLayerType: String, Decodable {
    case tile = "tilelayer"
    case object = "objectgroup"
    //case image = "imagelayer"
    //case group = "grouplayer"
}

struct TileMapModel: Decodable {
    let compressionlevel: Int
    let height: Int
    let infinite: Bool
    let layers: [AnyLayer]
    let nextlayerid: Int
    let nextobjectid: Int
    let orientation: String
    let renderorder: String
    let tiledversion: String
    let tileheight: Int
    let tilesets: [TileSet]
    let tilewidth: Int
    let type: String
    let version: String
    let width: Int
}

struct TileLayer: Decodable {
    let data: [Int]
    let height: Int
    let id: Int
    let name: String
    let opacity: Int
    let type: TiledLayerType.RawValue
    let visible: Bool
    let width: Int
    let x: Int
    let y: Int
}

struct ObjectLayer: Decodable {
    let draworder: String
    let id: Int
    let name: String
    let objects: [TiledObject]
    let opacity: Float
    let type: TiledLayerType.RawValue
    let visible: Bool
    let x: Int
    let y: Int
}

struct TiledObject: Decodable {
    let height: Float
    let id: Int
    let name: String
    let rotation: Float
    let type: String
    let visible: Bool
    let width: Float
    let x: Float
    let y: Float
}

struct TileSet: Decodable {
    let firstgid: Int
    let source: String
}

struct AnyLayer: Decodable {
    let layer: Any

    init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        let type = try container.decode(String.self, forKey: .type)

        switch type {
        case TiledLayerType.tile.rawValue:
            self.layer = try TileLayer(from: decoder)
        case TiledLayerType.object.rawValue:
            self.layer = try ObjectLayer(from: decoder)
        default:
            throw DecodingError.dataCorruptedError(
                forKey: .type,
                in: container,
                debugDescription: "Unknown layer type: \(type)"
            )
        }
    }

    private enum CodingKeys: String, CodingKey {
        case type
    }
}

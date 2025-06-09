import Raylib

enum TiledLayerType: String, Decodable {
    case tile = "tilelayer"
    case object = "objectlayer"
    //case image = "imagelayer"
    //case group = "grouplayer"
}

struct TileMapModel: Decodable {
    let compressionlevel: Int
    let height: Int
    let infinite: Bool
    let layers: [TileLayer]
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

import Foundation
import Raylib

enum ResourceManagerError: Error {
    case fileNotFound(String)
    case decodingFailed(String, Error)
    case textureLoadFailed(String)

    var description: String {
        switch self {
        case .fileNotFound(let path): return "Error: File not found at \(path)"
        case .decodingFailed(let path, let error):
            return "Error: Failed decoding of \(path) with error: \(error)"
        case .textureLoadFailed(let path): return "Error: Unable to load file at \(path)"
        }
    }
}

class ResourceManager {
    private var textureCache: [String: Texture2D] = [:]
    private var tileMapCache: [String: TileMapModel] = [:]

    func loadTileMapModel(from path: String) throws(ResourceManagerError) -> TileMapModel? {
        if let cached = tileMapCache[path] { return cached }

        let url = URL(fileURLWithPath: path)
        guard let data = try? Data(contentsOf: url) else {
            throw .fileNotFound(path)
        }

        do {
            let model = try JSONDecoder().decode(TileMapModel.self, from: data)
            tileMapCache[path] = model
            return model
        } catch {
            throw .decodingFailed(path, error)
        }
    }

    func loadTexture(from path: String) throws(ResourceManagerError) -> Texture2D? {
        if let cached = textureCache[path] { return cached }

        let texture = Raylib.loadTexture(path)
        guard texture.id != 0 else {
            throw .textureLoadFailed(path)
        }
        textureCache[path] = texture

        return texture
    }

    deinit {
        for texture in textureCache.values {
            Raylib.unloadTexture(texture)
        }
    }
}

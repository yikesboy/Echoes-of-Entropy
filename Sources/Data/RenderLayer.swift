enum RenderLayer: Int, CaseIterable, Comparable {
    case base = 0
    case tileMap = 100
    case decoration = 201
    case characters = 300
    case ui = 400

    static func < (lhs: RenderLayer, rhs: RenderLayer) -> Bool {
        return lhs.rawValue < rhs.rawValue
    }
}

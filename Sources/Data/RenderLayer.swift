enum RenderLayer: Int, CaseIterable, Comparable {
    case base = 0
    case decoration = 100
    case characters = 200
    case ui = 300

    static func < (lhs: RenderLayer, rhs: RenderLayer) -> Bool {
        return lhs.rawValue < rhs.rawValue
    }
}

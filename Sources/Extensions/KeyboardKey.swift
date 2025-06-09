import Raylib

extension KeyboardKey {
    var description: String {
        switch self {
        case .letterA: return "A"
        case .letterB: return "B"
        case .letterC: return "C"
        case .letterD: return "D"
        case .letterE: return "E"
        case .letterF: return "F"
        case .letterG: return "G"
        case .letterH: return "H"
        case .letterI: return "I"
        case .letterJ: return "J"
        case .letterK: return "K"
        case .letterL: return "L"
        case .letterM: return "M"
        case .letterN: return "N"
        case .letterO: return "O"
        case .letterP: return "P"
        case .letterQ: return "Q"
        case .letterR: return "R"
        case .letterS: return "S"
        case .letterT: return "T"
        case .letterU: return "U"
        case .letterV: return "V"
        case .letterW: return "W"
        case .letterX: return "X"
        case .letterY: return "Y"
        case .letterZ: return "Z"
        case .space: return "Space"
        default: return "Undefined"
        }
    }
}

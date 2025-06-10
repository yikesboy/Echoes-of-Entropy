import Foundation

struct GameState {
    var renderBuckets: [RenderLayer: [Entity]] = [:]

    mutating func add(_ drawable: Entity) {
        renderBuckets[drawable.renderLayer, default: []].append(drawable)
    }
}

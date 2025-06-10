import Raylib

struct RenderSystem {
    func render(_ scene: GameState?) {
        guard let scene = scene else { return }
        Raylib.beginDrawing()
        for layer in RenderLayer.allCases {
            scene.renderBuckets[layer]?.forEach { $0.draw() }
        }
        Raylib.endDrawing()
    }
}

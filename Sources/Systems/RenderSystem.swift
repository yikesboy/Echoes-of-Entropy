import Raylib

struct RenderSystem {
    func render(_ scene: GameState?) {
        guard let scene = scene else { return }
        Raylib.beginDrawing()
        for entity in scene.entities {
            entity.draw()
        }
        Raylib.endDrawing()
    }
}

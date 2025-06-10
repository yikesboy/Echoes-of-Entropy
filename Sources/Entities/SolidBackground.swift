import Raylib

struct SolidBackground: Entity {
    let color: Color
    let renderLayer: RenderLayer = .base

    func draw() {
        Raylib.clearBackground(color)
    }

    mutating func update(inputState: InputState, deltaTime: Float) {

    }
}

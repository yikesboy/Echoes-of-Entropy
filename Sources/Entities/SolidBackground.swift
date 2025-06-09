import Raylib

struct SolidBackground: Entity {
    let color: Color

    func draw() {
        Raylib.clearBackground(color)
    }

    mutating func update(inputState: InputState, deltaTime: Float) {

    }
}

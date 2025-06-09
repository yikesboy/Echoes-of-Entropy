import Raylib

struct Player: Entity {
    private var position: Vector2
    private let speed: Float = 250.0

    init(position: Vector2) {
        self.position = position
    }

    mutating func update(inputState: InputState, deltaTime: Float) {
        var dir = Vector2.zero

        if inputState.isActionDown(.moveUp) { dir.y -= 1 }
        if inputState.isActionDown(.moveDown) { dir.y += 1 }
        if inputState.isActionDown(.moveLeft) { dir.x -= 1 }
        if inputState.isActionDown(.moveRight) { dir.x += 1 }

        if dir.x != 0 || dir.y != 0 {
            dir = dir.normalized()
            position = position + dir.scale(speed * deltaTime)
        }

    }

    func draw() {
        Raylib.drawRectangle(Int32(position.x), Int32(position.y), 100, 50, .red)
    }
}

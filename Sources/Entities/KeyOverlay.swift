import Raylib

struct KeyOverlay: Entity {
    private var position: Vector2
    private var size: Vector2
    private var label: String
    private var isActive: Bool
    private let gameAction: GameAction

    let renderLayer: RenderLayer = .ui

    init(position: Vector2, label: String, gameAction: GameAction) {
        self.position = position
        self.size = Vector2(x: 50, y: 50)
        self.label = label
        self.isActive = false
        self.gameAction = gameAction
    }

    mutating func update(inputState: InputState, deltaTime: Float) {
        isActive = inputState.isActionDown(gameAction)
    }

    func draw() {
        Raylib.drawRectangleV(position, size, isActive ? .white : .gray)
        Raylib.drawText(label, Int32(position.x), Int32(position.y), 28, .black)
    }
}

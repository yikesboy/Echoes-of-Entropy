import Raylib

final class Game {
    private var sceneManager: SceneManager
    private let inputManager: InputSystem
    private var inputState: InputState
    private let updateSystem: UpdateSystem
    private let renderSystem: RenderSystem

    init() {
        self.sceneManager = SceneManager()
        self.inputManager = InputManager()
        self.inputState = InputState()
        self.updateSystem = UpdateSystem()
        self.renderSystem = RenderSystem()
    }

    func run() {
        setup()
        loop()
    }

    private func setup() {
        let gameName: String = "Echoes of Entropy"
        let screenWidth: Int32 = 800
        let screenHeight: Int32 = 450

        Raylib.initWindow(screenWidth, screenHeight, gameName)
        var scene = GameState()

        let bg = SolidBackground(color: .blue)
        scene.entities.append(bg)
        for (index, action) in GameAction.allCases.enumerated() {
            let position = Vector2(x: Float(index * 100), y: 100.0)
            let key = KeyOverlay(
                position: position, label: inputManager.getKey(for: action)?.description ?? "",
                gameAction: action)
            scene.entities.append(key)
        }

        sceneManager.loadScene(scene)
    }

    private func loop() {
        while Raylib.windowShouldClose == false {
            inputManager.updateState(&inputState)
            if var scene = sceneManager.currentScene {
                updateSystem.update(&scene, inputState: inputState)
                sceneManager.loadScene(scene)
            }
            renderSystem.render(sceneManager.currentScene)
        }

        Raylib.closeWindow()
    }
}

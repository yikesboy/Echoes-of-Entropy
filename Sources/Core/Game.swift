import Raylib

final class Game {
    private var sceneManager: SceneManager
    private let inputManager: InputSystem
    private var inputState: InputState
    private let updateSystem: UpdateSystem
    private let renderSystem: RenderSystem
    private let resourceManager: ResourceManager

    init() {
        self.sceneManager = SceneManager()
        self.inputManager = InputManager()
        self.inputState = InputState()
        self.updateSystem = UpdateSystem()
        self.renderSystem = RenderSystem()
        self.resourceManager = ResourceManager()
    }

    func run() {
        setup()
        loop()
    }

    private func setup() {
        let gameName: String = "Echoes of Entropy"
        let screenWidth: Int32 = 1200
        let screenHeight: Int32 = 600

        Raylib.initWindow(screenWidth, screenHeight, gameName)
        var scene = GameState()

        do {
            if let tmm = try resourceManager.loadTileMapModel(
                from: "/home/lukas/Uni/Computer-Games/swift-eoe/Assets/TileMap/tilemap"
            ) {
                let tileMap = TileMap(model: tmm)
                scene.add(tileMap)
            }
        } catch {
            print(error.description)
        }

        let bg = SolidBackground(color: .blue)
        let player = Player(
            position: Vector2(x: Float(screenWidth / 2), y: Float(screenHeight / 2)))
        scene.add(bg)
        scene.add(player)

        sceneManager.loadScene(scene)
    }

    private func loop() {
        while Raylib.windowShouldClose == false {
            let deltaTime = Raylib.getFrameTime()
            inputManager.updateState(&inputState)
            if var scene = sceneManager.currentScene {
                updateSystem.update(&scene, inputState: inputState, deltaTime: deltaTime)
                sceneManager.loadScene(scene)
            }
            renderSystem.render(sceneManager.currentScene)
        }

        Raylib.closeWindow()
    }
}

import Raylib

final class Game {
    private let inputManager: InputSystem
    private var inputState: InputState

    init() {
        self.inputManager = InputManager()
    }

    func run() {
        setup()
        loop()
    }

    private func setup() {
        let gameName: String = "Echoes of Entropy"
        let screenWidth: Int32 = 800
        let screenHeight: Int32 = 450
        let targetFPS: Int32 = 165
        Raylib.initWindow(screenWidth, screenHeight, gameName)
        //Raylib.setTargetFPS(targetFPS)
    }

    private func loop() {
        while Raylib.windowShouldClose == false {
            inputManager.updateState(inputState)
            Raylib.beginDrawing()
            Raylib.clearBackground(.skyBlue)
            Raylib.drawFPS(100, 100)
            Raylib.endDrawing()
        }

        Raylib.closeWindow()
    }
}

import Raylib

@main
final class Game {
    static func main() {
        let game = Game()
        game.setup()
        game.loop()
    }

    private func setup() {
        let gameName: String = "Echoes of Entropy"
        let screenWidth: Int32 = 800
        let screenHeight: Int32 = 450
        let targetFPS: Int32 = 165
        Raylib.initWindow(screenWidth, screenHeight, gameName)
        Raylib.setTargetFPS(targetFPS)
    }

    private func loop() {
        while Raylib.windowShouldClose == false {
            Raylib.beginDrawing()
            Raylib.clearBackground(.skyBlue)
            Raylib.drawFPS(100, 100)
            Raylib.endDrawing()
        }

        Raylib.closeWindow()
    }
}

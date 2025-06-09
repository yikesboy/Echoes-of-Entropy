class SceneManager {
    private(set) var currentScene: GameState?

    func loadScene(_ scene: GameState) {
        currentScene = scene
    }
}

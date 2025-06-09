struct UpdateSystem {
    func update(_ scene: inout GameState, inputState: InputState, deltaTime: Float) {
        for index in scene.entities.indices {
            scene.entities[index].update(inputState: inputState, deltaTime: deltaTime)
        }
    }
}

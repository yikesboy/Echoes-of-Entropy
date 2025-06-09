struct UpdateSystem {
    func update(_ scene: inout GameState, inputState: InputState) {
        for index in scene.entities.indices {
            scene.entities[index].update(inputState: inputState)
        }
    }
}

protocol InputSystem {
    func isActionDown(_ action: GameAction) -> Bool
    func isKeyPressed(_ action: GameAction) -> Bool
    func updateState(_ state: InputState)
}

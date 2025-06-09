struct InputState {
    private var actionStates: [GameAction: Bool] = [:]

    mutating func update(action: GameAction, isActive: Bool) {
        actionStates[action] = isActive
    }

    func isActionDown(_ action: GameAction) -> Bool {
        if let state = actionStates[action] {
            return state
        }
        return false
    }
}

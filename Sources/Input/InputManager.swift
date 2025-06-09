import Raylib

final class InputManager: InputSystem {
    private var keyBindings: [GameAction: KeyboardKey]

    init() {
        keyBindings = [:]
    }

    func isActionDown(_ action: GameAction) -> Bool {
        guard let key = keyBindings[action] else {
            return false
        }
        return Raylib.isKeyDown(key)
    }

    func isKeyPressed(_ action: GameAction) -> Bool {
        guard let key = keyBindings[action] else {
            return false
        }
        return Raylib.isKeyPressed(key)
    }

    func updateState(_ state: inout InputState) {
        for (action, _) in keyBindings {
            state.update(action: action, isActive: isActionDown(action))
        }
    }
}

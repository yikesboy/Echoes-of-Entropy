struct UpdateSystem {
    func update(_ scene: inout GameState, inputState: InputState, deltaTime: Float) {
        for layer in RenderLayer.allCases {
            guard var bucket = scene.renderBuckets[layer] else { continue }
            for index in bucket.indices {
                bucket[index].update(inputState: inputState, deltaTime: deltaTime)
            }
            scene.renderBuckets[layer] = bucket
        }
    }
}

import Raylib

protocol Collidable {
    var collisionBounds: Rectangle { get }
    var collisionLayer: CollisionLayer { get }
    func onCollision(with other: Collidable)
}

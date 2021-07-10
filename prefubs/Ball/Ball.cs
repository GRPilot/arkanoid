using Godot;
using System;

public class Ball : KinematicBody2D {
    private Sprite sprite;
    private CollisionShape2D collisionShape;

    [Export] public float speed = 100;
    [Export] public Vector2 force = new Vector2();

    public override void _Ready() {
        sprite = GetNode<Sprite>("Sprite");
        collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
    }

    public void SetForceDirection(Vector2 force) {
        this.force = force;
    }

    public override void _PhysicsProcess(float delta) {
        speed += delta;
        force *= GetForceDirection(GetViewportRect().Size);
        force = force.Normalized();
        var collision = MoveAndCollide(force * speed * delta, true, true, true);
        if (collision != null) {
            force = force.Bounce(collision.Normal);
        }
        MoveAndCollide(force * speed * delta);
    }

    private Vector2 GetForceDirection(Vector2 size) {
        var position = sprite.GlobalPosition;
        var scale = collisionShape.Scale.x;
        var radius = (sprite.Texture.GetWidth() * scale) / 2.0f;

        Vector2 forceDirection = new Vector2(1, 1);
        if(position.x + radius >= size.x || position.x - radius <= 0) {
            forceDirection.x *= -1;
        }
        if(position.y + radius >= size.y || position.y - radius <= 0) {
            forceDirection.y *= -1;
        }
        return forceDirection;
    }

}

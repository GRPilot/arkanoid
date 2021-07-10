using Godot;
using System;

public class Platform : StaticBody2D {
    [Export] public float smooth = 100;
    [Export] public float maxVelocity = 500.0f;

    public override void _PhysicsProcess(float delta) {
        Vector2 offset = MovementOffset();
        ConstantLinearVelocity += offset * delta;
        NormalizeVelocity();
        BoundWithWalls();
        Position += ConstantLinearVelocity;
    }

    private Vector2 MovementOffset() {
        Vector2 offset = new Vector2();
        bool wasPressed = false;
        if(Input.IsActionPressed("ui_left")) {
            wasPressed = true;
            offset.x = -smooth;
        }
        if(Input.IsActionPressed("ui_right")) {
            wasPressed = true;
            offset.x = smooth;
        }
        if(wasPressed) {
            return offset;
        }

        Vector2 velocity = ConstantLinearVelocity;
        float absVelocityX = Math.Abs(velocity.x);
        if(absVelocityX == 0) {
            return offset;
        }
        float coef = velocity.x / absVelocityX;
        if(absVelocityX < 1.0) {
            offset.x = absVelocityX * -coef;
            if(Math.Abs(offset.x) < 0.01) {
                offset.x = 0;
                ConstantLinearVelocity = new Vector2();
            }
            return offset;
        }
        offset.x = smooth * -coef;
        return offset;
    }

    private void NormalizeVelocity() {
        float absVelocityX = Math.Abs(ConstantLinearVelocity.x);
        float coef = absVelocityX / ConstantLinearVelocity.x;
        if(absVelocityX > maxVelocity) {
            ConstantLinearVelocity = new Vector2(coef * maxVelocity, 0);
        }
    }

    private void BoundWithWalls() {
        var screensize = GetViewportRect().Size;
        var xOffset = GetNode<Sprite>("Sprite").Texture.GetSize().x / 2;
        var xPos = Position.x;
        Vector2 bounding = new Vector2(1, 1);
        float safeOffset = xOffset + 1;
        if(xPos - xOffset <= 0) {
            Position = new Vector2(safeOffset, Position.y);
            bounding.x = -Bounce;
        }

        if(xPos + xOffset >= screensize.x) {
            Position = new Vector2(screensize.x - safeOffset, Position.y);
            bounding.x = -Bounce;
        }
        ConstantLinearVelocity *= bounding;
    }
}

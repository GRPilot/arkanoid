using Godot;
using System;

public class Platform : RigidBody2D {
    [Export] public float smooth = 2000f;
    [Export] public float maxVelocity = 500.0f;
    private Vector2 nullVector = new Vector2(0, 0);

    public override void _PhysicsProcess(float delta) {
        Vector2 impulse = new Vector2();
        if(Input.IsActionPressed("ui_left")) {
            impulse.x = -smooth * Mass * delta;
        }
        if(Input.IsActionPressed("ui_right")) {
            impulse.x = smooth * Mass * delta;
        }
        ApplyImpulse(nullVector, impulse);
        NormalizeVelocity();
    }

    public override void _IntegrateForces(Physics2DDirectBodyState state) {
        base._IntegrateForces(state);
        Vector2 screensize = GetViewportRect().Size;
        Transform2D xform = state.Transform;
        if(xform.origin.x > screensize.x) {
            xform.origin.x = 0;
        } else if(xform.origin.x < 0) {
            xform.origin.x = screensize.x;
        }
        state.Transform = xform;
    }

    private void NormalizeVelocity() {
        float absVelocityX = Math.Abs(LinearVelocity.x);
        float coef = absVelocityX / LinearVelocity.x;
        if(absVelocityX > maxVelocity) {
            LinearVelocity = new Vector2(coef * maxVelocity, 0);
        }
    }
}

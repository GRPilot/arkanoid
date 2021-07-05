using Godot;
using System;

public class Ball : RigidBody2D {

    [Export] public float speed = 1000;

    public override void _Ready() {
    }

    public override void _PhysicsProcess(float delta) {
        base._PhysicsProcess(delta);
    }
}

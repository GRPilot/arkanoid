using Godot;
using System;

public class GameScene : Node2D {
    private bool gameStarted = false;
    public override void _Ready() {
        
    }

    public override void _Input(InputEvent @event) {
        base._Input(@event);
        if(gameStarted) {
            return;
        }

        if(@event.IsActionPressed("ui_accept")) {
            gameStarted = true;

            Ball ball = GetNode<Ball>("Ball");
            Vector2 force = new Vector2(RandomFloat(-1.0f, 1.0f), RandomFloat(-1.0f, 1.0f));
            ball.SetForceDirection(force);
        }
    }

    private float RandomFloat(float from, float to) {
        Random rand = new Random(DateTime.UtcNow.Millisecond);
        double value = rand.NextDouble() * (from - to) * from;
        return (float)value;
    }
}

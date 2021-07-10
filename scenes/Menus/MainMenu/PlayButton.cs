using Godot;
using System;

public class PlayButton : SoundButton {
    public override void _Ready() {
        base._Ready();
        Connect("pressed", this, nameof(OnPressed));
    }

    public void OnPressed() {
        GetNode<Tools>("/root/Tools").ChangeScene("res://scenes/GameScene/GameScene.tscn");
    }
}

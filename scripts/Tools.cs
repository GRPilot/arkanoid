using Godot;
using System;

public class Tools : Node {
    public void ChangeScene(string name) {
        PackedScene scene = ResourceLoader.Load<PackedScene>(name);
        if(null == scene) {
            GD.PrintErr($"[Global] [ChangeScene] Cannot load {name} scene");
            return;
        }
        GetTree().ChangeSceneTo(scene);
    }
}

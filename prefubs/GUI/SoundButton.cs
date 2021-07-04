using Godot;
using System;

public class SoundButton : Button {

    public override void _Ready() {
        base._Ready();
        Connect("button_down", this, nameof(ClickSound));
        Connect("mouse_entered", this, nameof(HoveredSound));
    }

    public void ClickSound() {
        if(!Disabled) {
            GetNode<SoundManager>("/root/SoundManager").Play(SoundManager.Sounds.ClickSound);
        }
    }

    public void HoveredSound() {
        if(!Disabled) {
            GetNode<SoundManager>("/root/SoundManager").Play(SoundManager.Sounds.HoverSound);
        }
    }
}

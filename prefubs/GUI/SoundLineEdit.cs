using Godot;
using System;

public class SoundLineEdit : LineEdit {
    public override void _Ready() {
        Connect("text_changed", this, nameof(OnTextChanging));
    }

    public void OnTextChanging(string newText) {
        if(Editable) {
            GetNode<SoundManager>("/root/SoundManager").Play(SoundManager.Sounds.ClickSound);
        }
    }
}

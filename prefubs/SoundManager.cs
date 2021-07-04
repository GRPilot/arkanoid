using Godot;
using System.Collections.Generic;
using System;

public class SoundManager : Node2D {
    public enum Sounds {
        ClickSound,
        HoverSound,
        BoundSound,
        SoundsCount ///< always last
    };

    private SortedDictionary<Sounds, AudioStreamPlayer> samples;

    public SoundManager() {
        GD.Print("[SoundManager] Initializing...");
        samples = new SortedDictionary<Sounds, AudioStreamPlayer>();
        GD.Print("[SoundManager] Initializing done");
    }

    public override void _Ready() {
        GD.Print("[SoundManager] Generating audio streams players...");
        Generate(Sounds.ClickSound);
        Generate(Sounds.HoverSound);
        Generate(Sounds.BoundSound);

        string status = $"({samples.Count}/{((int)Sounds.SoundsCount)})";
        GD.Print("[SoundManager] Generating audio streams players done: ", status);
    }

    public void Play(Sounds sound) {
        GD.Print("[SoundManager] Start playing ", sound.ToString());
        samples[sound].Play();
    }

    private void Generate(Sounds sound) {
        samples[sound] = GetNode<AudioStreamPlayer>(sound.ToString());
    }

}

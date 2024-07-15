using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimationPlayer;
    [Export] public Sprite3D Sprite;
    [Export] public StateMachine StateMachine;

    public Vector2 Direction = new();
    public int Speed = 5;

    public override void _Input(InputEvent @event)
    {
        Direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveForward,
            GameConstants.InputMoveBackward);
    }
}

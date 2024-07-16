using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimationPlayer { get; private set; }
    [Export] public Sprite3D Sprite { get; private set; }
    [Export] public StateMachine StateMachine { get; private set; }

    public Vector2 Direction = new();

    public override void _Input(InputEvent @event)
    {
        Direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveForward,
            GameConstants.InputMoveBackward);
    }

    public void Flip()
    {
        if (Direction.X == 0)
        {
            return;
        }
        Sprite.FlipH = Direction.X < 0;
    }
}

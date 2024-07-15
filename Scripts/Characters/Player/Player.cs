using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimationPlayer;
    [Export] public Sprite3D Sprite;
    [Export] public StateMachine StateMachine;

    public Vector2 Direction = new();

    private int speed = 5;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(Direction.X, 0, Direction.Y);
        Velocity *= speed;

        MoveAndSlide();
        ChangeDirection(Direction);
    }

    public override void _Input(InputEvent @event)
    {
        Direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveForward,
            GameConstants.InputMoveBackward);
    }

    private void ChangeDirection(Vector2 direction)
    {
        if (direction.X == 0)
        {
            return;
        }
        Sprite.FlipH = direction.X < 0;
    }
}

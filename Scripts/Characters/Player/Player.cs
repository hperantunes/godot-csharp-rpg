using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimationPlayer;
    [Export] public Sprite3D Sprite;

    private Vector2 direction = new();
    private int speed = 5;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= speed;

        MoveAndSlide();
        ChangeDirection(Velocity);
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveForward,
            GameConstants.InputMoveBackward);
    }

    private void ChangeDirection(Vector3 velocity)
    {
        if (velocity.X == 0)
        {
            return;
        }
        Sprite.FlipH = velocity.X < 0;
    }
}

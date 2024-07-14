using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer animationPlayer;
    [Export] private Sprite3D sprite;

    private Vector2 direction = new();
    private int speed = 5;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= speed;

        MoveAndSlide();
        AnimateMovement(Velocity);
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
            GameConstants.InputMoveLeft,
            GameConstants.InputMoveRight,
            GameConstants.InputMoveForward,
            GameConstants.InputMoveBackward);
    }

    private void AnimateMovement(Vector3 velocity)
    {
        if (velocity == Vector3.Zero)
        {
            animationPlayer.Play(GameConstants.AnimationIdle);
            return;
        }

        animationPlayer.Play(GameConstants.AnimationMove);

        if (velocity.X == 0)
        {
            return;
        }

        sprite.FlipH = velocity.X < 0;
    }
}

using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer animationPlayer;
    [Export] private Sprite3D sprite;

    private Vector2 direction = new();
    private int speed = 5;

    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= speed;

        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward");

        if (direction != Vector2.Zero)
        {
            animationPlayer.Play("Move");
        }
        else
        {
            animationPlayer.Play("Idle");
        }
    }
}

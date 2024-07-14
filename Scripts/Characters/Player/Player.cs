using Godot;
using System;

public partial class Player : CharacterBody3D
{
    private Vector2 direction = new();
    private int speed = 5;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= speed;
        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward");
    }
}

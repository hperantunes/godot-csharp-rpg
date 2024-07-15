using Godot;
using System;

public partial class PlayerDashState : Node
{
    private Player character;
    [Export] private Timer dashTimer;
    [Export] private float speed = 10;

    public override void _Ready()
    {
        character = GetOwner<Player>();
        dashTimer.Timeout += HandleDashTimerTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        character.MoveAndSlide();
        character.Flip();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            character.AnimationPlayer.Play(GameConstants.AnimationDash);
            character.Velocity = new(character.Direction.X, 0, character.Direction.Y);

            if (character.Velocity == Vector3.Zero)
            {
                character.Velocity = character.Sprite.FlipH
                    ? Vector3.Left
                    : Vector3.Right;
            }

            character.Velocity *= speed;
            dashTimer.Start();
        }
    }

    private void HandleDashTimerTimeout()
    {
        character.Velocity = Vector3.Zero;
        character.StateMachine.ChangeState<PlayerIdleState>();
    }
}

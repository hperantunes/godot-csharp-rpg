using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimer;
    [Export(PropertyHint.Range, "0,20,0.1")] private float speed = 10;

    public override void _Ready()
    {
        base._Ready();
        dashTimer.Timeout += HandleDashTimerTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        character.MoveAndSlide();
        character.Flip();
    }

    protected override void EnterState()
    {
        base.EnterState();
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

    private void HandleDashTimerTimeout()
    {
        character.Velocity = Vector3.Zero;
        character.StateMachine.ChangeState<PlayerIdleState>();
    }
}

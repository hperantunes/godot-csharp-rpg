using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if (character.Direction == Vector2.Zero)
        {
            character.StateMachine.ChangeState<PlayerIdleState>();
            return;
        }

        character.Velocity = new(character.Direction.X, 0, character.Direction.Y);
        character.Velocity *= character.Speed;
        character.MoveAndSlide();
        character.Flip();
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.InputDash))
        {
            character.StateMachine.ChangeState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();
        character.AnimationPlayer.Play(GameConstants.AnimationMove);
    }
}

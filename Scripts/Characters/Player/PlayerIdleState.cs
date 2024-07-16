using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if (character.Direction != Vector2.Zero)
        {
            character.StateMachine.ChangeState<PlayerMoveState>();
        }
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
        character.AnimationPlayer.Play(GameConstants.AnimationIdle);
    }
}

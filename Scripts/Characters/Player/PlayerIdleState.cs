using Godot;
using System;

public partial class PlayerIdleState : Node
{
    private Player character;

    public override void _Ready()
    {
        character = GetOwner<Player>();
        SetPhysicsProcess(false);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (character.Direction != Vector2.Zero)
        {
            character.StateMachine.ChangeState<PlayerMoveState>();
        }
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            SetPhysicsProcess(true);
            character.AnimationPlayer.Play(GameConstants.AnimationIdle);
        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false);
        }
    }
}

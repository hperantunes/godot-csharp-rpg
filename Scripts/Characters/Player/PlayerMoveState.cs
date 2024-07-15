using Godot;
using System;

public partial class PlayerMoveState : Node
{
    private Player character;

    public override void _Ready()
    {
        character = GetOwner<Player>();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (character.Direction == Vector2.Zero)
        {
            character.StateMachine.ChangeState<PlayerIdleState>();
        }
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            var player = GetOwner<Player>();
            player.AnimationPlayer.Play(GameConstants.AnimationMove);
        }
    }
}

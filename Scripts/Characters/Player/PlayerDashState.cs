using Godot;
using System;

public partial class PlayerDashState : Node
{
    private Player character;
    [Export] private Timer dashTimer; 

    public override void _Ready()
    {
        character = GetOwner<Player>();
        dashTimer.Timeout += HandleDashTimerTimeout;
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            character.AnimationPlayer.Play(GameConstants.AnimationDash);
            dashTimer.Start();
        }
    }

    private void HandleDashTimerTimeout()
    {
        character.StateMachine.ChangeState<PlayerIdleState>();
    }
}

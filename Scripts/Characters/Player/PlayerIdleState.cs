using Godot;
using System;

public partial class PlayerIdleState : Node
{
    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            var player = GetOwner<Player>();
            player.AnimationPlayer.Play(GameConstants.AnimationIdle);
        }
    }
}

using Godot;
using System;

public partial class PlayerIdleState : Node
{
    public override void _Ready()
    {
        var player = GetOwner<Player>();
        player.AnimationPlayer.Play(GameConstants.AnimationIdle);
    }
}

using Godot;
using System;

public partial class PlayerMoveState : Node
{
    public override void _Ready()
    {
        var player = GetOwner<Player>();
        player.AnimationPlayer.Play(GameConstants.AnimationMove);
    }
}

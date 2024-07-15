using Godot;
using System;

public partial class PlayerDashState : Node
{
    private Player character;

    public override void _Ready()
    {
        character = GetOwner<Player>();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            character.AnimationPlayer.Play(GameConstants.AnimationDash);
        }
    }
}

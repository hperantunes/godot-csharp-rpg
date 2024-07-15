using Godot;
using System;

public partial class PlayerMoveState : Node
{
    private Player character;

    public override void _Ready()
    {
        character = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

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
        
        Flip(character.Direction);
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            SetPhysicsProcess(true);
            SetProcessInput(true);
            character.AnimationPlayer.Play(GameConstants.AnimationMove);
        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.InputDash))
        {
            character.StateMachine.ChangeState<PlayerDashState>();
        }
    }

    private void Flip(Vector2 direction)
    {
        if (direction.X == 0)
        {
            return;
        }
        character.Sprite.FlipH = direction.X < 0;
    }
}

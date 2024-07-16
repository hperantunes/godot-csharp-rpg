using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentState;
    [Export] private Node[] states = Array.Empty<Node>();

    public override void _Ready()
    {
        currentState.Notification(GameConstants.NotificationEnterState);
    }

    public void ChangeState<T>() where T : Node
    {
        var newState = Array.Find(states, state => state is T);
        if (newState == null || newState == currentState)
        {
            return;
        }

        currentState.Notification(GameConstants.NotificationExitState);
        currentState = newState;
        currentState.Notification(GameConstants.NotificationEnterState);
    }
}

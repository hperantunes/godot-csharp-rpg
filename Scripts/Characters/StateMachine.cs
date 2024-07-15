using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentState;
    [Export] private Node[] states = Array.Empty<Node>();

    public override void _Ready()
    {
        currentState.Notification(5001);
    }

    public void ChangeState<T>() where T : Node
    {
        var newState = Array.Find(states, state => state is T);
        if (newState == null || newState == currentState)
        {
            return;
        }
        newState.Notification(5001);
        currentState = newState;
    }
}

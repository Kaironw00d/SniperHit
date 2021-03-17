using UnityEngine;

public class BaseEventState : MonoBehaviour, IEventState
{
    protected string Name { get; set; }
    public StateMachine StateMachine { get; protected set; }

    public virtual void Init(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
        StateMachine.OnStateChange += HandleState;
    }

    public virtual void HandleState(string stateName)
    {
        
    }

    public virtual bool CanHandleState(string stateName) => stateName == Name;
}
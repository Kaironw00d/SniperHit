public interface IState
{
    StateMachine StateMachine { get; }

    void Init(StateMachine stateMachine);
}
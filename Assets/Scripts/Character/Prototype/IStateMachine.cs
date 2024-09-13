public interface IStateMachine<T> where T : IState
{
    T CurrentState { get; }
    void Initialize(T startingState);
    void ChangeState(T newState);
}


public class StateMachine<T> : IStateMachine<T> where T : IState
{
    public T CurrentState { get; private set; }

    public virtual void Initialize(T startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public virtual void ChangeState(T newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
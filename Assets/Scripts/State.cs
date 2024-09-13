using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void Exit();
    void Update();
}

public abstract class CharacterState<T> : IState
    where T : StateMachine<IState>
{
    public Animator Anim { get; protected set; }
    public T StateMachine { get; protected set; }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}

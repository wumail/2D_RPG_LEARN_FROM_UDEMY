using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void Exit();
    void Update();
    void AnimationTrigger();
}

public abstract class CharacterState<T> : IState
    where T : StateMachine<IState>
{
    public Entity<T, IState> Character { get; protected set; }
    public Animator Anim { get; protected set; }
    public Rigidbody2D Rb { get; protected set; }
    public T StateMachine { get; protected set; }

    protected string animBoolName;
    protected bool triggerCalled;
    protected float stateTimer;

    public virtual void Enter()
    {
        triggerCalled = false;

    }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void AnimationTrigger() { triggerCalled = true; }

}

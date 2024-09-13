using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : CharacterState<StateMachine<IState>>
{
    public Enemy enemyBase;

    protected IStateMachine<EnemyState> stateMachine;

    public EnemyState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        enemyBase = _enemyBase;
        stateMachine = _stateMachine;
        animBoolName = _animBoolName;
        Rb = enemyBase.Rb;
    }

    public override void Enter()
    {
        base.Enter();
        enemyBase.Anim.SetBool(animBoolName, true);
    }
    public override void Update() {
        stateTimer -= Time.deltaTime;
     }
    public override void Exit()
    {
        enemyBase.Anim.SetBool(animBoolName, false);

    }
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }
}

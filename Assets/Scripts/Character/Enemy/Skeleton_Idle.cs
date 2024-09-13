using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdle : EnemySkeletonGrounded
{
    Skeleton enemy;
    public SkeletonIdle(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 1f;
        enemy.SetVelocity(0f, 0f);
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer < 0){
            stateMachine.ChangeState(enemy.walkState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

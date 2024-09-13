using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWalk : EnemySkeletonGrounded
{

    Skeleton enemy;
    public SkeletonWalk(Skeleton _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton _enemy): base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        
        enemy.SetVelocity(enemy.moveSpeed  * enemy.facingDir, Rb.velocity.y);
        
        if(enemy.IsWallDetected() || !enemy.IsGroundDetected()){
            enemy.FlipController(enemy.facingDir * -1);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

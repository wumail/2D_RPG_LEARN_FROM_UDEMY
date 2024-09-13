using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine: StateMachine<EnemyState>
{
    public new EnemyState CurrentState { get; private set; }
    public override void Initialize(EnemyState startingState)
    {
        base.Initialize(startingState);
    }

    public override void ChangeState(EnemyState newState)
    {
       base.ChangeState(newState);
    }
}

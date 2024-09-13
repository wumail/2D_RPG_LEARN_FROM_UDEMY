using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemyStateMachine: StateMachine<EnemyState>
{
    public override void Initialize(EnemyState startingState)
    {
        base.Initialize(startingState);
    }

    public override void ChangeState(EnemyState newState)
    {
       base.ChangeState(newState);
    }
}

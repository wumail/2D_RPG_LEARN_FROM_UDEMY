using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerState>
{
    public override void Initialize(PlayerState startingState)
    {
        base.Initialize(startingState);
    }
    public override void ChangeState(PlayerState newState)
    {
        base.ChangeState(newState);
    }
}

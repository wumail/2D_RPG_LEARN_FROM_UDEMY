using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerGrounded
{
    public PlayerIdle(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0f, 0f);
    }

    public override void Update()
    {
        base.Update();

        if(xInput != 0 && !player.IsBusy)
        {
            stateMachine.ChangeState(player.MoveState);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}

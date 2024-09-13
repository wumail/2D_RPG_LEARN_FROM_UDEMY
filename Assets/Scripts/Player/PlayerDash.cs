using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : PlayerState
{

    public PlayerDash(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTime = player.dashDuration;
    }

    public override void Update()
    {
        base.Update();
        stateTime -= Time.deltaTime;
        player.SetVelocity(player.dashDir * player.dashSpeed, 0);
        if (stateTime <= 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        if(player.IsWallDetected() && !player.IsGroundDetected()){
            stateMachine.ChangeState(player.WallSlideState);
        }
    }

    public override void Exit()
    {
        player.SetVelocity(0, Rb.velocity.y);
        base.Exit();
    }
}

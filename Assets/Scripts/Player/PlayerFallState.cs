using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : PlayerAirState
{
    public PlayerFall(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        // player.SetVelocity(xInput * player.moveSpeed, Rb.velocity.y);

        if(xInput != 0){
            player.SetVelocity(xInput * player.moveSpeed * .6f, Rb.velocity.y);
        }

        if(player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

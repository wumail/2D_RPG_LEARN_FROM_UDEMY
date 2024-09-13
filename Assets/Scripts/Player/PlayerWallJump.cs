using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : PlayerJump
{
    public PlayerWallJump(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(player.moveSpeed / 2 * player.facingDir, player.jumpForce * .8f);
    }

    public override void Update()
    {
        base.Update();

        if(player.IsGroundDetected()){
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}

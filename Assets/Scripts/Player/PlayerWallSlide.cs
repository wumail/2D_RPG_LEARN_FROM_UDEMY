using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlide : PlayerState
{
    private float WallFacing;
    public PlayerWallSlide(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        WallFacing = player.facingDir * -1;
        player.SetDashFacing(WallFacing);

        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        
        if(Input.GetKeyDown(KeyCode.Space)){
            stateMachine.ChangeState(player.WallJumpState);
            return;
        }else if(Input.GetKeyDown(KeyCode.LeftShift)){
            stateMachine.ChangeState(player.DashState);
            return;
        }

        if(yInput < 0)
            player.SetVelocity(Rb.velocity.x, Rb.velocity.y);
        else 
            player.SetVelocity(Rb.velocity.x, Rb.velocity.y / 2);
        
        if(player.IsGroundDetected()){
            stateMachine.ChangeState(player.IdleState);
        }else if(xInput != 0 && player.facingDir != xInput){
            if(Input.GetKeyDown(KeyCode.Space)){
                stateMachine.ChangeState(player.WallJumpState);
                return;
            }
            stateMachine.ChangeState(player.IdleState);
        }else if(!player.IsWallDetected()){
            stateMachine.ChangeState(player.FallState);
        }
    }

    public override void Exit()
    {
        player.FlipController(WallFacing);
        base.Exit();
    }
}

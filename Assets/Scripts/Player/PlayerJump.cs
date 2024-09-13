using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerAirState
{
    // generate constructor
    public PlayerJump(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    // override methods

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(Rb.velocity.x, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();

        
        // if(xInput != 0){
        //     player.SetVelocity(xInput * player.moveSpeed * .4f, Rb.velocity.y);
        // }

        // // player.SetVelocity(xInput * player.moveSpeed, Rb.velocity.y);

        if(Rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.FallState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

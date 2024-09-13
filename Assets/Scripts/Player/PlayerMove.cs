using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerGrounded
{
    // generate constructor
    public PlayerMove(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    // override methods

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (player.IsGroundDetected())
        {
            if (xInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else
            {
                player.SetVelocity(xInput * player.moveSpeed, Rb.velocity.y);
            }
        }
        else
        {
            stateMachine.ChangeState(player.FallState);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}

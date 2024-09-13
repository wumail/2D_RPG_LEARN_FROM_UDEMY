using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : PlayerState
{
    public PlayerGrounded(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (!player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.FallState);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(player.AttackState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        player.Rb.velocity = new Vector2(0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if(player.IsWallDetected() && !player.IsGroundDetected()){
            stateMachine.ChangeState(player.WallSlideState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerState
{
    // generate constructor and empty override methods

    private float lastAttackTime;
    private float attackWindow = 2;
    private int comboCount = 0;

    public PlayerAttack(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if(lastAttackTime != 0 && Time.time >= lastAttackTime + attackWindow)
        {
            comboCount = 0;
        }
        
        if(xInput != 0)
        {
            player.FlipController(xInput);
        }

        player.Anim.SetInteger("comboCount", comboCount);
        player.SetVelocity(player.attackMoveList[comboCount].x * player.facingDir, player.attackMoveList[comboCount].y);
    }

    public override void Update()
    {
        base.Update();

        if(triggerCalled){
            stateMachine.ChangeState(player.IdleState);
        }

        player.Rb.velocity = new Vector2(0, 0);
    }

    public override void Exit()
    {
        base.Exit();
        lastAttackTime = Time.time;
        comboCount = (comboCount + 1) % 3;
        player.StartCoroutine("SetBusy", .1f);
    }

}

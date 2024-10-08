using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState: CharacterState<StateMachine<IState>>
{
    protected Player player;
    protected IStateMachine<PlayerState> stateMachine;
    protected Rigidbody2D Rb;

    protected float stateTime;

    protected float xInput;
    protected float yInput;
    private string animBoolName;

    protected bool triggerCalled;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        Rb = player.Rb;
    }

    override public void Enter()
    {
        player.Anim.SetBool(animBoolName, true);
        triggerCalled = false;
    }

    override public void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        // player.SetVelocity(xInput * player.moveSpeed, Rb.velocity.y);
        player.Anim.SetFloat("yVelocity", player.Rb.velocity.y);
    }

    override public void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }

    public void AnimationTrigger()
    {
        triggerCalled = true;
    }
}

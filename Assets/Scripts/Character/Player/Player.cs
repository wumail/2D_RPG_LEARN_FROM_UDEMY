using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;

public class Player : Entity<PlayerStateMachine, PlayerState>
{

    # region Player States
    public PlayerIdle IdleState { get; private set; }
    public PlayerMove MoveState { get; private set; }
    public PlayerJump JumpState { get; private set; }
    public PlayerFall FallState { get; private set; }
    public PlayerDash DashState { get; private set; }
    public PlayerWallSlide WallSlideState { get; private set; }
    public PlayerWallJump WallJumpState { get; private set; }
    public PlayerAttack AttackState { get; private set; }
   
    # endregion

    [Header("Dash States")]
    public float dashTimer;
    public float dashCoolDown = 1f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashDir {get; private set;}

    protected override void Awake()
    {
        base.Awake();

        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdle(this, StateMachine, "idle");
        MoveState = new PlayerMove(this, StateMachine, "move");
        JumpState = new PlayerJump(this, StateMachine, "jump");
        FallState = new PlayerFall(this, StateMachine, "jump");
        DashState = new PlayerDash(this, StateMachine, "dash");
        WallSlideState = new PlayerWallSlide(this, StateMachine, "wallSlide");
        WallJumpState = new PlayerWallJump(this, StateMachine, "jump");
        AttackState = new PlayerAttack(this, StateMachine, "attack");
    }

    protected override void Start()
    {
        base.Start();
        Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();
        dashTimer -= Time.deltaTime;

        if(dashTimer <= 0 && Input.GetKeyDown(KeyCode.LeftShift) && !StateMachine.CurrentState.Equals(WallSlideState))
        {
            dashDir = Input.GetAxisRaw("Horizontal");

            if(dashDir == 0 ){
                dashDir = facingDir;
            }

            StateMachine.ChangeState(DashState);
            dashTimer = dashCoolDown;
        }
    }

    public void SetDashFacing(float dir){
        dashDir = dir;
    }
}

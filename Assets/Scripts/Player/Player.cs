using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;

public class Player : Character<PlayerStateMachine, PlayerState>
{
    public bool IsBusy { get; private set; }

    # region Components
    # endregion

    # region States
    public PlayerIdle IdleState { get; private set; }
    public PlayerMove MoveState { get; private set; }
    public PlayerJump JumpState { get; private set; }
    public PlayerFall FallState { get; private set; }
    public PlayerDash DashState { get; private set; }
    public PlayerWallSlide WallSlideState { get; private set; }
    public PlayerWallJump WallJumpState { get; private set; }
    public PlayerAttack AttackState { get; private set; }

    [Header("Player States")]
    public float moveSpeed = 10;
    public float jumpForce = 10f;

    public float facingDir;

    [Header("Attack States")]
    public List<Vector2> attackMoveList;

    [Header("Collision States")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;

    [Header("Dash States")]
    public float dashTimer;
    public float dashCoolDown = 1f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashDir {get; private set;}

    # endregion

    new private void Awake()
    {
        base.Awake();
        facingDir = 1f;

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

    new private void Start()
    {
        StateMachine.Initialize(IdleState);
    }

    new private void Update()
    {
        StateMachine.CurrentState.Update();
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

    public IEnumerator SetBusy(float time)
    {
        IsBusy = true;
        yield return new WaitForSeconds(time);
        IsBusy = false;
    }

    public void SetDashFacing(float dir){
        dashDir = dir;
    }
    public void SetVelocity(float xVelocity, float yVelocity)
    {
        Rb.velocity = new Vector2(xVelocity, yVelocity);
        if(xVelocity != 0) FlipController(Mathf.Sign(xVelocity));
    }

    public  void AnimationTrigger() => (StateMachine.CurrentState as PlayerState).AnimationTrigger();

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundMask);

    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, groundMask);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
    }

    public void FlipController(float direction)
    {        
        if (direction != facingDir)
        {
            facingDir = direction;
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
}

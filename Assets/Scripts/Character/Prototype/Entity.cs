using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity<T, K> : MonoBehaviour
     where K : IState
     where T : StateMachine<K>
{
    #region components
    public Animator Anim { get; protected set; }
    public Rigidbody2D Rb { get; protected set; }
    public T StateMachine { get; protected set; }
    #endregion

    #region Character States
    public bool IsBusy { get; protected set; }

    [Header("Character States")]
    public float moveSpeed = 10;
    public float jumpForce = 10f;
    public float facingDir;

    [Header("Attack States")]
    public List<Vector2> attackMoveList;

    [Header("Collision States")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask groundMask;

    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;

    #endregion

    protected virtual void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponentInChildren<Animator>();
        facingDir = 1f;
    }

    protected virtual void Start()
    {
    
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        StateMachine.CurrentState.Update();
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
    }

    protected virtual void Initialize(K state)
    {
        StateMachine.Initialize(state);
    }

    public virtual IEnumerator SetBusy(float time)
    {
        IsBusy = true;
        yield return new WaitForSeconds(time);
        IsBusy = false;
    }

    public virtual void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    public virtual void SetVelocity(float xVelocity, float yVelocity)
    {
        Rb.velocity = new Vector2(xVelocity, yVelocity);
        if (xVelocity != 0) FlipController(Mathf.Sign(xVelocity));
    }

    #region Collision Checks
    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundMask);

    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, groundMask);

    #endregion

    #region  Flip
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
    #endregion
}

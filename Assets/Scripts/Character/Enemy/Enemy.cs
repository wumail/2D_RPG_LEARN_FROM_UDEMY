using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity<EnemyStateMachine, EnemyState>
{
    [Header("Enemy States")]
    [SerializeField] protected float idleTime = 1f;
    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine();
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }

}
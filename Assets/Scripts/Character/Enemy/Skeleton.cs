using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;

public class Skeleton : Enemy{

    #region  Enemy States
    public SkeletonIdle idleState;
    public SkeletonWalk walkState;

    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new SkeletonIdle(this, StateMachine, "idle", this);
        walkState = new SkeletonWalk(this, StateMachine, "walk", this);
    }
    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(idleState);
    }
    protected override void Update()
    {
        base.Update();
    }

}
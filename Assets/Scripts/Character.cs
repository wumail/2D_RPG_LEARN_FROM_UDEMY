using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character<T, K>: MonoBehaviour
     where K: IState
     where T: StateMachine<K>
{
    public Animator Anim { get; protected set; }
    public Rigidbody2D Rb { get; protected set; }
    public T StateMachine { get; protected set; }

    protected virtual void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponentInChildren<Animator>();   
    }

    protected virtual void Start()
    {
        return;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        return;
    }
}

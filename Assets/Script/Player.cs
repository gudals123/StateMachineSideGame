using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move info")]
    public float moveSpeed = 12f;


    public PlayerStateMachine stateMachine { get; private set; }

    public Animator animator { get; private set; }
    public Rigidbody2D rb { get; private set; }


    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);
    }             

    private void Update()
    {
        stateMachine.currentState.Update();
    }


    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);

    }
}

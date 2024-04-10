using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PhysicsCheck physicsCheck;
    private PlayerController playerController;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        physicsCheck = GetComponent<PhysicsCheck>();
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetAnimation();
    }

    public void SetAnimation()
    {
        animator.SetBool("isGround", physicsCheck.isGround);
        animator.SetBool("isRun", playerController.isRun);

        animator.SetFloat("velocityY", rb.velocity.y);
    }
}

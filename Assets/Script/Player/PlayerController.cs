using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;

    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    private CapsuleCollider2D coll;
    private AudioDefination audioDefination;//添加音效
    //当前player的位置
    private Vector2 currentPosition;

    [Header("基本参数")]
    public float speed;//运动速度
    public float jumpForce;//跳跃力度

    [Header("状态")]
    public bool isRun;

    [Header("物理材质")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;

    private void Awake()
    {
        inputControl = new PlayerInputControl();
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        coll = GetComponent<CapsuleCollider2D>();
        audioDefination = GetComponent<AudioDefination>();
        isRun = false;
        //跳跃
        inputControl.GamePlayer.Jump.started += Jump;
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        currentPosition = inputControl.GamePlayer.Move.ReadValue<Vector2>();

        //物理材质转换,根据人物此时的状态
        checkStats();

    }

    private void checkStats()
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
    }

    //产生移动通常在FixedUpdate中调用
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(currentPosition.x * speed * Time.deltaTime, rb.velocity.y);
        //人物翻转
        int fadeDir = (int)transform.localScale.x;
        if (currentPosition.x > 0)
        {
            fadeDir = -1;
            isRun = true;
        }
        if (currentPosition.x < 0)
        {
            fadeDir = 1;
            isRun = true;
        }
        if (currentPosition.x == 0)
            isRun = false;
        transform.localScale = new Vector3(fadeDir, 1, 1);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (physicsCheck.isGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            audioDefination.PlayAudioClip();
        }
    }
}

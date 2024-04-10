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
    private AudioDefination audioDefination;//�����Ч
    //��ǰplayer��λ��
    private Vector2 currentPosition;

    [Header("��������")]
    public float speed;//�˶��ٶ�
    public float jumpForce;//��Ծ����

    [Header("״̬")]
    public bool isRun;

    [Header("�������")]
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
        //��Ծ
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

        //�������ת��,���������ʱ��״̬
        checkStats();

    }

    private void checkStats()
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
    }

    //�����ƶ�ͨ����FixedUpdate�е���
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(currentPosition.x * speed * Time.deltaTime, rb.velocity.y);
        //���﷭ת
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

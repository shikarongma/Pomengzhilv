using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    //�ֶ����Ƽ��λ��
    public Vector2 bottomOffset;
    public Vector2 leftOffest;
    public Vector2 rightOffest;
    //��ⷶΧ
    public float checkRaduis;
    public LayerMask groundLayer;

    [Header("״̬")]
    public bool isGround;
    //ײ��ǽ
    public bool touchLeftWall;
    //ײ��ǽ
    public bool touchRightWall;

    private void Update()
    {
        Check();
    }

    private void Check()
    {
        //������
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRaduis, groundLayer);
        //�����ǽ
        touchLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffest, checkRaduis, groundLayer);
        //�����ǽ
        touchRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffest, checkRaduis, groundLayer);
    }

    //��Ȧ
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffest, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffest, checkRaduis);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    //ÊÖ¶¯¿ØÖÆ¼ì²âÎ»ÖÃ
    public Vector2 bottomOffset;
    public Vector2 leftOffest;
    public Vector2 rightOffest;
    //¼ì²â·¶Î§
    public float checkRaduis;
    public LayerMask groundLayer;

    [Header("×´Ì¬")]
    public bool isGround;
    //×²×óÇ½
    public bool touchLeftWall;
    //×²ÓÒÇ½
    public bool touchRightWall;

    private void Update()
    {
        Check();
    }

    private void Check()
    {
        //¼ì²âµØÃæ
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRaduis, groundLayer);
        //¼ì²â×óÇ½
        touchLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffest, checkRaduis, groundLayer);
        //¼ì²âÓÐÇ½
        touchRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffest, checkRaduis, groundLayer);
    }

    //»­È¦
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffest, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffest, checkRaduis);
    }
}

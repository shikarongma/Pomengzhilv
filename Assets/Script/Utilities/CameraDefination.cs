using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDefination : MonoBehaviour
{
    [Header("事件发出")]
    public ChangePositionEventSO changeCameraPositionSO;//改变摄像机位置

    [Header("基本参数")]
    public Vector3 nextCameraPosition;//下一个摄像机的位置

    public DestroyStarManager5 destroyStarManager5;

    private BoxCollider2D boxCollider2D;
    public BoxCollider2D BoundCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (destroyStarManager5.Counts == 4)
        {
            boxCollider2D.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BoundCollider2D.isTrigger = false;
            changeCameraPositionSO.RarisedEvent(nextCameraPosition);
        }
    }
}

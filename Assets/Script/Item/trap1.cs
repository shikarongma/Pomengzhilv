using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap1 : MonoBehaviour
{
    //碰到陷阱重玩
    public GameSceneSO currentScene;
    public Vector3 currentPosition;

    [Header("发出事件")]
    public SceneChangeEventSO ChangeEventSO;
    public ChangePositionEventSO changecameraPositionSO;//改变摄像机位置
    public Vector3 cameraPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeEventSO.RaiseEvent(currentScene, currentPosition, true);
            changecameraPositionSO.RarisedEvent(cameraPosition);
        }
    }
}

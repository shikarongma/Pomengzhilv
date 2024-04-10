using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    //������������
    public GameSceneSO currentScene;
    public Vector3 currentPosition;

    [Header("�����¼�")]
    public SceneChangeEventSO ChangeEventSO;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeEventSO.RaiseEvent(currentScene, currentPosition, true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour,IInteractable
{
    public GameSceneSO nextSceneSO;//ǰ������һ������
    public Vector3 position;//palyerȥ������һ������

    [Header("�¼�����")]
    public SceneChangeEventSO changeEventSO;

    //���÷���


    //ʵ�ֿɽ�������Ľӿڷ���
    public void TiggerAction()
    {
        changeEventSO.RaiseEvent(nextSceneSO,position, true);
    }
}

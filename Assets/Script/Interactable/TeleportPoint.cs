using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour,IInteractable
{
    public GameSceneSO nextSceneSO;//前往的下一个场景
    public Vector3 position;//palyer去往的下一个坐标

    [Header("事件发出")]
    public SceneChangeEventSO changeEventSO;

    //调用方法


    //实现可交互对象的接口方法
    public void TiggerAction()
    {
        changeEventSO.RaiseEvent(nextSceneSO,position, true);
    }
}

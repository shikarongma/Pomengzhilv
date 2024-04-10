using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStarManager4 : MonoBehaviour,DestroyStar
{
    private int counts = 4;

    [Header("事件监听")]
    public DestroyStarEventSO destroyStarEventSO;//销毁星星

    [Header("事件发出")]
    public SceneChangeEventSO changeSceneSO;//转换场景

    [Header("基本参数")]
    public GameSceneSO nextScene;
    public Vector3 nextPosition;

    private void OnEnable()
    {
        destroyStarEventSO.OnEventRaised += StarEvent;
    }

    private void OnDisable()
    {
        destroyStarEventSO.OnEventRaised -= StarEvent;
    }

    private void StarEvent(int order)
    {
        DestroyStarEvent(order);
    }

    public void DestroyStarEvent(int order)
    {
        counts--;
        if (counts == 0)
            changeSceneSO.RaiseEvent(nextScene, nextPosition, true);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStarManager2 : MonoBehaviour,DestroyStar
{
    [Header("事件监听")]
    public DestroyStarEventSO destroyStarEventSO;

    [Header("事件发出")]
    public SceneChangeEventSO ChangeEventSO;

    [Header("基本参数")]
    public GameSceneSO currentScene;//当前场景
    public GameSceneSO nextScene;//下一个场景
    public Vector3 currentPosition;//当前场景玩家降落位置
    public Vector3 nextPosition;//下一个场景玩家降落位置

    //实时跟进当前消灭的星星
    private int sum = 0;

    private void Update()
    {
        if (sum == 5)
        {
            ChangeEventSO.RaiseEvent(nextScene, nextPosition, true);
        }
    }

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
        sum++;
        if (sum != order)
        {
            ChangeEventSO.RaiseEvent(currentScene, currentPosition, true);
        }

    }

    public void DestroyStarEvent()
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestroyStarManager : MonoBehaviour,DestroyStar
{
    [Header("事件监听")]
    public DestroyStarEventSO deatroyStarSO;

    [Header("事件发出")]
    public SceneChangeEventSO ChangeEventSO;

    [Header("基本参数")]
    public GameSceneSO currentScene;//当前的场景
    public GameSceneSO nextSceneSO;//前往的下一个场景
    public Vector3 currentPosition;//当前场景需要到达的位置
    public Vector3 nextPosition;//palyer去往的下一个坐标

    private int Counts = 6;

    private void Update()
    {
        if (Counts == 0)
        {
            ChangeEventSO.RaiseEvent(nextSceneSO,nextPosition,true);
        }
    }

    private void OnEnable()
    {
        deatroyStarSO.OnEventRaised += StarCount;
    }

    private void OnDisable()
    {
        deatroyStarSO.OnEventRaised -= StarCount;
    }

    private void StarCount(int order)
    {
        DestroyStarEvent(order);
    }

    public void DestroyStarEvent(int order)
    {
        Counts--;
    }

    //玩家掉出，重新开始这一关卡
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeEventSO.RaiseEvent(currentScene,currentPosition,true);
        }
    }
}

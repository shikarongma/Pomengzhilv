using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStarManager3 : MonoBehaviour,DestroyStar
{
    private int counts = 5;
    private int[] allOrder = { 1, 2, 3, 4, 5 };
    private int currentOrder;
    public Vector3[] position = new Vector3[5];

    [Header("事件监听")]
    public DestroyStarEventSO destroystarSO;//星星被玩家吃掉事件

    [Header("事件发出")]
    public SceneChangeEventSO changeEventSO;//场景交换事件
    public ChangePositionEventSO changePositionEventSO;//星星位置交换事件


    [Header("基本参数")]
    public GameSceneSO nextScene;
    public Vector3 nextPosition;

    private void OnEnable()
    {
        destroystarSO.OnEventRaised += StarEvent;
    }

    private void OnDisable()
    {
        destroystarSO.OnEventRaised -= StarEvent;
    }

    private void StarEvent(int order)
    {
        DestroyStarEvent(order);
    }

    public void DestroyStarEvent(int order)
    {
        counts--;
        allOrder[order - 1] = -1;
        if (counts == 0)
        {
            changeEventSO.RaiseEvent(nextScene, nextPosition, true);
        }
        if (counts == 1)
        {
            for(int i = 0; i < allOrder.Length; i++)
            {
                if (allOrder[i] != -1)
                {
                    currentOrder = allOrder[i];
                    break;
                }
            }
            StartCoroutine(ChangePosition(currentOrder));
        }
    }

    IEnumerator ChangePosition(int order)
    {
        while (counts==1)
        {
            yield return new WaitForSeconds(1.6f);
            order++;
            changePositionEventSO.RarisedEvent(position[order % 5]);
        }
    }
}

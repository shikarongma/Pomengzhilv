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

    [Header("�¼�����")]
    public DestroyStarEventSO destroystarSO;//���Ǳ���ҳԵ��¼�

    [Header("�¼�����")]
    public SceneChangeEventSO changeEventSO;//���������¼�
    public ChangePositionEventSO changePositionEventSO;//����λ�ý����¼�


    [Header("��������")]
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

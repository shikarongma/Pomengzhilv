using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStarManager2 : MonoBehaviour,DestroyStar
{
    [Header("�¼�����")]
    public DestroyStarEventSO destroyStarEventSO;

    [Header("�¼�����")]
    public SceneChangeEventSO ChangeEventSO;

    [Header("��������")]
    public GameSceneSO currentScene;//��ǰ����
    public GameSceneSO nextScene;//��һ������
    public Vector3 currentPosition;//��ǰ������ҽ���λ��
    public Vector3 nextPosition;//��һ��������ҽ���λ��

    //ʵʱ������ǰ���������
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

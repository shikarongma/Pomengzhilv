using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestroyStarManager : MonoBehaviour,DestroyStar
{
    [Header("�¼�����")]
    public DestroyStarEventSO deatroyStarSO;

    [Header("�¼�����")]
    public SceneChangeEventSO ChangeEventSO;

    [Header("��������")]
    public GameSceneSO currentScene;//��ǰ�ĳ���
    public GameSceneSO nextSceneSO;//ǰ������һ������
    public Vector3 currentPosition;//��ǰ������Ҫ�����λ��
    public Vector3 nextPosition;//palyerȥ������һ������

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

    //��ҵ��������¿�ʼ��һ�ؿ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeEventSO.RaiseEvent(currentScene,currentPosition,true);
        }
    }
}

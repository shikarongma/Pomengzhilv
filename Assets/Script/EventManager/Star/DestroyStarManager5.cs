using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class DestroyStarManager5 : MonoBehaviour
{
    [Header("�¼�����")]
    public DestroyStarEventSO deatroyStarSO;

    [Header("�¼�����")]
    public SceneChangeEventSO ChangeEventSO;//�л�����
    public ChangePositionEventSO changeCameraPositionSO;//�ı������λ��

    [Header("��������")]
    public GameSceneSO nextSceneSO;//ǰ������һ������
    public Vector3 nextPosition;//palyerȥ������һ������

    public Vector3 currentCameraPosition;//��ǰ�����λ��

    public AudioDefination audioDefination;

    [HideInInspector] public int Counts = 0;

    private void Update()
    {
        if (Counts == 7)
        {
            //������ع�ԭ��λ��
            changeCameraPositionSO.RarisedEvent(currentCameraPosition);
            audioDefination.PlayAudioClip();
            ChangeEventSO.RaiseEvent(nextSceneSO, nextPosition, true);
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
        Counts++;
    }
}

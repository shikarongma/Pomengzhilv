using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDefination : MonoBehaviour
{
    [Header("�¼�����")]
    public PlayAudioEventSO PlayAudioEventSO;
    public AudioClip clip;
    public bool playOnEnable;//�Ƿ�һ��ʼ�Ͳ���

    private void OnEnable()
    {
        if (playOnEnable)
        {
            PlayAudioClip();
        }
    }

    public void PlayAudioClip()
    {
        PlayAudioEventSO.RaisedEvent(clip);
    }
}

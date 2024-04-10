using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDefination : MonoBehaviour
{
    [Header("事件发出")]
    public PlayAudioEventSO PlayAudioEventSO;
    public AudioClip clip;
    public bool playOnEnable;//是否一开始就播放

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

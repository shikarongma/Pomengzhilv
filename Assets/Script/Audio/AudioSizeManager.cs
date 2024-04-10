using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSizeManager : MonoBehaviour
{
    public ChangeSoundSizeSO sizeSO;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        sizeSO.OnEventRaised += changeEvent;
    }

    private void OnDisable()
    {
        sizeSO.OnEventRaised -= changeEvent;
    }

    private void changeEvent(Slider slider)
    {
        audioSource.volume = slider.value;
    }
}

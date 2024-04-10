using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcceptSoundManager : MonoBehaviour
{
    public Slider BGMSlider;
    public Slider FXSlider;
    [Header("ÊÂ¼þ¼àÌý")]
    public RentrunSoundSO rentrunSoundSO;

    private void OnEnable()
    {
        rentrunSoundSO.OnEventRaised += RenturnSound;
    }

    private void OnDisable()
    {
        rentrunSoundSO.OnEventRaised -= RenturnSound;
    }

    private void RenturnSound(AudioSource BGMSource, AudioSource FXSourse)
    {
        BGMSlider.value = BGMSource.volume;
        FXSlider.value = FXSourse.volume;
    }
}

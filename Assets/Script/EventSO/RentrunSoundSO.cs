using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Event/RentrunSoundSO")]
public class RentrunSoundSO : ScriptableObject
{
    public UnityAction<AudioSource, AudioSource> OnEventRaised;

    public void RaisedEvent(AudioSource BGMSourse,AudioSource FXSourse)
    {
        OnEventRaised?.Invoke(BGMSourse, FXSourse);
    }
}

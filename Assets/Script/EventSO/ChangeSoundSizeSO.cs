using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Event/ChangeSoundSizeSO")]
public class ChangeSoundSizeSO : ScriptableObject
{
    public UnityAction<Slider> OnEventRaised;

    public void RaisedEvent(Slider slider)
    {
        OnEventRaised?.Invoke(slider);
    }
}

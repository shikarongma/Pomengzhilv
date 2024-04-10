using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Event/FadeCanvasSO")]
public class FadeCanvasSO : ScriptableObject
{
    //渐入渐出的颜色和时间
    public UnityAction<Color, float> onEventRaised;

    //变黑
    public void FadeIn(float duration)
    {
        RaisedEvent(Color.black, duration);
    }

    //变透明
    public void FadeOut(float duration)
    {
        RaisedEvent(Color.clear, duration);
    }

    public void RaisedEvent(Color target,float duration)
    {
        onEventRaised?.Invoke(target,duration);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;//需要在应用商店下载插件

public class FadeCancasManager : MonoBehaviour
{
    //渐入渐出图片
    public Image fadeImage;

    [Header("事件监听")]
    public FadeCanvasSO fadeEvent;

    private void OnEnable()
    {
        fadeEvent.onEventRaised += OnFadeEvent;
    }
    private void OnDisable()
    {
        fadeEvent.onEventRaised -= OnFadeEvent;
    }

    private void OnFadeEvent(Color target, float duration)
    {
        fadeImage.DOBlendableColor(target, duration);
    }
}

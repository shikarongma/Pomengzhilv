using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;//��Ҫ��Ӧ���̵����ز��

public class FadeCancasManager : MonoBehaviour
{
    //���뽥��ͼƬ
    public Image fadeImage;

    [Header("�¼�����")]
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

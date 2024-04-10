using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionManager : MonoBehaviour
{
    [Header("�¼�����")]
    public ChangePositionEventSO changePositionSO;

    [Header("�¼�����")]
    public FadeCanvasSO fadeCanvasSO;

    private void OnEnable()
    {
        changePositionSO.OnEventRaised += ChangePosition;
    }

    private void OnDisable()
    {
        changePositionSO.OnEventRaised -= ChangePosition;
    }

    private void ChangePosition(Vector3 position)
    {
        gameObject.transform.position = new Vector3(position.x, position.y, position.z);
    }
}

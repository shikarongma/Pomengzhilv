using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionManager : MonoBehaviour
{
    [Header("事件监听")]
    public ChangePositionEventSO changePositionSO;

    [Header("事件发出")]
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

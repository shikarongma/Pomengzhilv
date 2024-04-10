using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Event/ChangePosiotionEventSO")]
public class ChangePositionEventSO : ScriptableObject
{
    public UnityAction<Vector3> OnEventRaised;

    public void RarisedEvent(Vector3 position)
    {
        OnEventRaised?.Invoke(position);
    }
}

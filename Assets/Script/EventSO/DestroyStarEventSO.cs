using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Event/VoidEventSO")]
public class DestroyStarEventSO : ScriptableObject
{
    public UnityAction<int> OnEventRaised;

    public void RaiseEvent(int order)
    {
        OnEventRaised?.Invoke(order);
    }
}

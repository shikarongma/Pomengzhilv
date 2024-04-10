using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Event/SceneChangeEventSO")]
public class SceneChangeEventSO : ScriptableObject//���������¼�
{
    public UnityAction<GameSceneSO, Vector3, bool> OnEventRaise;

    public void RaiseEvent(GameSceneSO locationToLoade,Vector3 position, bool fadeScreen)
    {
        OnEventRaise?.Invoke(locationToLoade, position, fadeScreen);
    }
}

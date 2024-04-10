using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class DestroyStarManager5 : MonoBehaviour
{
    [Header("事件监听")]
    public DestroyStarEventSO deatroyStarSO;

    [Header("事件发出")]
    public SceneChangeEventSO ChangeEventSO;//切换场景
    public ChangePositionEventSO changeCameraPositionSO;//改变摄像机位置

    [Header("基本参数")]
    public GameSceneSO nextSceneSO;//前往的下一个场景
    public Vector3 nextPosition;//palyer去往的下一个坐标

    public Vector3 currentCameraPosition;//当前摄像机位置

    public AudioDefination audioDefination;

    [HideInInspector] public int Counts = 0;

    private void Update()
    {
        if (Counts == 7)
        {
            //摄像机回归原本位置
            changeCameraPositionSO.RarisedEvent(currentCameraPosition);
            audioDefination.PlayAudioClip();
            ChangeEventSO.RaiseEvent(nextSceneSO, nextPosition, true);
        }
    }

    private void OnEnable()
    {
        deatroyStarSO.OnEventRaised += StarCount;
    }

    private void OnDisable()
    {
        deatroyStarSO.OnEventRaised -= StarCount;
    }

    private void StarCount(int order)
    {
        DestroyStarEvent(order);
    }

    public void DestroyStarEvent(int order)
    {
        Counts++;
    }
}

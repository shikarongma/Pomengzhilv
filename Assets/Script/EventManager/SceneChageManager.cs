using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneChageManager : MonoBehaviour
{
    //人物
    public Transform playerTrans;
    [Header("事件监听")]
    public SceneChangeEventSO changeEventSO;//监听交换场景

    //开始时进入的第一个场景（主菜单）
    public GameSceneSO firstScene;

    [Header("事件发出")]
    public FadeCanvasSO fadeEventSO;//发出渐入渐出
    public RentrunSoundSO rentrunSoundSO;//发出音量传回


    private GameSceneSO currentScene;//当前场景
    private GameSceneSO sceneChange;//下一个场景
    private Vector2 positionTogo;//玩家去往的坐标

    private bool isChange;//判断当前是否在交换场景
    private bool fadeScreen;//判断是否渐入渐出

    public float fadeTime;//渐入渐出时间

    //设置场景则需要把此时的音量传过去
    public AudioSource BGMSourse;
    public AudioSource FXSourse;
    private void Awake()
    {
        currentScene = firstScene;
        //加载当前场景
        currentScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
    }

    private void OnEnable()
    {
        changeEventSO.OnEventRaise += OnChangeEvent;
    }

    private void OnDisable()
    {
        changeEventSO.OnEventRaise -= OnChangeEvent;
    }

    private void OnChangeEvent(GameSceneSO sceneTogo, Vector3 posTogo, bool fadeScreen)
    {
        //如果当前正在交换场景，玩家点击按键将不会作出反应
        if (isChange)
            return;
        isChange = true;
        sceneChange = sceneTogo;
        positionTogo = posTogo;
        this.fadeScreen = fadeScreen;
        //调用协程
        if (changeEventSO != null)
        {
            StartCoroutine(UnLoadPreviousScene());
        }
    }

    //协程
    private IEnumerator UnLoadPreviousScene()
    {
        if (fadeScreen)//变黑
        {
            fadeEventSO.FadeIn(fadeTime);
        }

        yield return new WaitForSeconds(fadeTime);
        //卸载场景
        yield return currentScene.sceneReference.UnLoadScene();
        
        playerTrans.gameObject.SetActive(false);
        //加载新场景
        LoadNewScene();
    }

    //加载新场景的方法
    private void LoadNewScene()
    {
        var loadingOption = sceneChange.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        loadingOption.Completed += OnLoadCompleted;
    }

    /// <summary>
    /// 场景加载完成后
    /// </summary>
    /// <param name="obj"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void OnLoadCompleted(AsyncOperationHandle<SceneInstance> obj)
    {
        currentScene = sceneChange;//当前场景切换为换到的那个场景
        //如果此时场景为设置页面，则需要发出事件，将音量传过去
        if (currentScene.name == "Setting")
        {
            rentrunSoundSO.RaisedEvent(BGMSourse, FXSourse);
        }
        //移动完坐标后，再将player启动
        playerTrans.position = positionTogo;
        if (!(currentScene.sceneType == SceneType.Menu))
            playerTrans.gameObject.SetActive(true);


        if (fadeScreen)//渐入渐出效果 变透明
        {
            //TODO
            fadeEventSO.FadeOut(fadeTime);
        }

        isChange = false;

        //场景加载完成后事件
    }
}

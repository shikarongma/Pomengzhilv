using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneChageManager : MonoBehaviour
{
    //����
    public Transform playerTrans;
    [Header("�¼�����")]
    public SceneChangeEventSO changeEventSO;//������������

    //��ʼʱ����ĵ�һ�����������˵���
    public GameSceneSO firstScene;

    [Header("�¼�����")]
    public FadeCanvasSO fadeEventSO;//�������뽥��
    public RentrunSoundSO rentrunSoundSO;//������������


    private GameSceneSO currentScene;//��ǰ����
    private GameSceneSO sceneChange;//��һ������
    private Vector2 positionTogo;//���ȥ��������

    private bool isChange;//�жϵ�ǰ�Ƿ��ڽ�������
    private bool fadeScreen;//�ж��Ƿ��뽥��

    public float fadeTime;//���뽥��ʱ��

    //���ó�������Ҫ�Ѵ�ʱ����������ȥ
    public AudioSource BGMSourse;
    public AudioSource FXSourse;
    private void Awake()
    {
        currentScene = firstScene;
        //���ص�ǰ����
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
        //�����ǰ���ڽ�����������ҵ������������������Ӧ
        if (isChange)
            return;
        isChange = true;
        sceneChange = sceneTogo;
        positionTogo = posTogo;
        this.fadeScreen = fadeScreen;
        //����Э��
        if (changeEventSO != null)
        {
            StartCoroutine(UnLoadPreviousScene());
        }
    }

    //Э��
    private IEnumerator UnLoadPreviousScene()
    {
        if (fadeScreen)//���
        {
            fadeEventSO.FadeIn(fadeTime);
        }

        yield return new WaitForSeconds(fadeTime);
        //ж�س���
        yield return currentScene.sceneReference.UnLoadScene();
        
        playerTrans.gameObject.SetActive(false);
        //�����³���
        LoadNewScene();
    }

    //�����³����ķ���
    private void LoadNewScene()
    {
        var loadingOption = sceneChange.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        loadingOption.Completed += OnLoadCompleted;
    }

    /// <summary>
    /// ����������ɺ�
    /// </summary>
    /// <param name="obj"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void OnLoadCompleted(AsyncOperationHandle<SceneInstance> obj)
    {
        currentScene = sceneChange;//��ǰ�����л�Ϊ�������Ǹ�����
        //�����ʱ����Ϊ����ҳ�棬����Ҫ�����¼�������������ȥ
        if (currentScene.name == "Setting")
        {
            rentrunSoundSO.RaisedEvent(BGMSourse, FXSourse);
        }
        //�ƶ���������ٽ�player����
        playerTrans.position = positionTogo;
        if (!(currentScene.sceneType == SceneType.Menu))
            playerTrans.gameObject.SetActive(true);


        if (fadeScreen)//���뽥��Ч�� ��͸��
        {
            //TODO
            fadeEventSO.FadeOut(fadeTime);
        }

        isChange = false;

        //����������ɺ��¼�
    }
}

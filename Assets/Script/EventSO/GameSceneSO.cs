using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;//��Ҫ����Addressables���

[CreateAssetMenu(menuName ="Game Scene/GameSceneSO")]
public class GameSceneSO : ScriptableObject
{
    public SceneType sceneType;//��������
    public AssetReference sceneReference;//Asset����
}

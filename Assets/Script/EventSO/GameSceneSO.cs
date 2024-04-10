using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;//需要下载Addressables插件

[CreateAssetMenu(menuName ="Game Scene/GameSceneSO")]
public class GameSceneSO : ScriptableObject
{
    public SceneType sceneType;//场景类型
    public AssetReference sceneReference;//Asset引用
}

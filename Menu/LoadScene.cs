using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private Text progressText;
    private AsyncOperation async;

    public void StartLoad(int _sceneID)
    {
        StartCoroutine(loadScene(_sceneID));
        async.allowSceneActivation = true;
    }

    IEnumerator loadScene(int _sceneID)
    {
        async = SceneManager.LoadSceneAsync(_sceneID, LoadSceneMode.Single);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            progressText.text = async.progress/0.9f * 100 + "";
            yield return null;
        }

    }
}

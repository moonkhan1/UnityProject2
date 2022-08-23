using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Abstracts.Utilities;
using UnityEngine.SceneManagement;

namespace UnityProject2.Managers{

public class GameManager : SingletonMonoBehaviorObject<GameManager>
{

    public event System.Action OnGameStop;
    private void Awake() 
    {
        SingletonThisObject(this);    
    }

    public void StopGame()
    {
        Time.timeScale = 0f;

        OnGameStop?.Invoke();// If it is not null then run.
    }

    public void LoadScene(string sceneName)
    {
        // Debug.Log("Load scene clicked");
        StartCoroutine(LoadSceneAsync(sceneName));

    }

    private IEnumerator LoadSceneAsync(string scene)
    {
        Time.timeScale = 1f;
        yield return SceneManager.LoadSceneAsync(scene);
    }
    public void ExitGame()
    {
        Debug.Log("Exit scene clicked");
        Application.Quit();
    }
}
}

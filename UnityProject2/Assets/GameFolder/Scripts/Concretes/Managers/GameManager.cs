using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Abstracts.Utilities;
using UnityEngine.SceneManagement;
using UnityProject2.ScriptableObjects;
using UnityProject2.Controllers;

namespace UnityProject2.Managers{

public class GameManager : SingletonMonoBehaviorObject<GameManager>
{
    [SerializeField] LevelDifficultyData[] _levelDifficultyDatas;

    public event System.Action OnGameStop;

    public LevelDifficultyData LevelDifficultyData => _levelDifficultyDatas[DifficultyIndex];

    int _difficultyIndex;

    public int DifficultyIndex
    { get => _difficultyIndex;
      set
      {
        if(_difficultyIndex < 0 || _difficultyIndex > _levelDifficultyDatas.Length)
        {
            LoadSceneAsync("Menu");
        }
        else{
            _difficultyIndex = value;
        }
      } 
    }

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

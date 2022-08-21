using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Abstracts.Utilities;

namespace UnityProject2.Managers{

public class GameManager : SingletonMonoBehaviorObject<GameManager>
{
    private void Awake() 
    {
        SingletonThisObject(this);    
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
    }

    public void LoadScene()
    {
        Debug.Log("Load scene clicked");
    }
    public void ExitGame()
    {
        Debug.Log("Exit scene clicked");
        Application.Quit();
    }
}
}

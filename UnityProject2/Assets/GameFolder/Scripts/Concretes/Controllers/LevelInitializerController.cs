using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityProject2.ScriptableObjects;
using UnityProject2.Managers;

namespace UnityProject2.Controllers
{

public class LevelInitializerController : MonoBehaviour 
    

{
    LevelDifficultyData _levelDifficultyData;

    private void Awake() {
        _levelDifficultyData = GameManager.Instance.LevelDifficultyData;
    }

    private void Start() {
        RenderSettings.skybox = _levelDifficultyData.SkyboxMaterial;
        Instantiate(_levelDifficultyData.FloorPrefeb);
        Instantiate(_levelDifficultyData.SpawnerPrefeb);
        EnemyManager.Instance.SetMoveSpeed(_levelDifficultyData.MoveSpeed);
        EnemyManager.Instance.SetAddDelayTime(_levelDifficultyData.AddDelayTime);
    }
}
}
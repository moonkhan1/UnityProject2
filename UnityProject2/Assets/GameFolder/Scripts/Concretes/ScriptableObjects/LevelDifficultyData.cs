using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Controllers;


namespace UnityProject2.ScriptableObjects
{
    
    [CreateAssetMenu(fileName = "Level Difficulty", menuName = "Create Difficulty/Create New", order = 1)]

    public class LevelDifficultyData : ScriptableObject 
    {
        [SerializeField] FloorController _floorPrefeb;
        [SerializeField] GameObject _spawnersPrefeb;
        [SerializeField] Material _skyboxMaterial;
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _addDelayTime = 50f;

        public FloorController FloorPrefeb => _floorPrefeb;
        public GameObject SpawnerPrefeb => _spawnersPrefeb;
        public Material SkyboxMaterial => _skyboxMaterial;
        public float MoveSpeed => _moveSpeed;
        public float AddDelayTime => _addDelayTime;

    }
    
}


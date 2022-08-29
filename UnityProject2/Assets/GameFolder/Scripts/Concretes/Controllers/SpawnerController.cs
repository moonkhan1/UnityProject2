using System.Threading;
// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Managers;
using UnityProject2.Controllers;
using UnityProject2.Enums;

namespace UnityProject2.Controllers{
public class SpawnerController : MonoBehaviour
{
    // [SerializeField] EnemyController _enemyPrefeb; artiq EnemyController classinin ozumdedir
    [Range(0.2f,5f)][SerializeField] float _min = 0.2f;
    [Range(6f,15f)][SerializeField] float _max = 15f;

    float _maxSpawnTime;
    float _currentSpawnTime = 0f;
    int _index = 0;
    float _maxAddEnemyTime;

    public bool CanIncrease => _index < EnemyManager.Instance.Count;

    private void OnEnable() 
    {
        GetRandomMaxTime();
    }
    private void Update() 
    {
        _currentSpawnTime += Time.deltaTime;
        if(_currentSpawnTime > _maxSpawnTime)
        {
            Spawn();
        }

        if(!CanIncrease) return;
        
        if(_maxAddEnemyTime < Time.time)
        {
            _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
            IncreaseIndex();
        }
    }
    private void Spawn()
    {
        // -- Artiq Dusmen yaratmaq EnemyManagerdedir--
        // Dusmenin Spawn olmasi ve birdefelik Hierarchy'de Spawn oldugu Spawnerin childe'si kimi spawn olmasi
        // EnemyController newEnemy = Instantiate(_enemyPrefeb,transform.position, transform.rotation);
        
        EnemyController newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0,_index));
        newEnemy.transform.parent = this.transform;
        newEnemy.transform.position = this.transform.position;
        newEnemy.gameObject.SetActive(true);

        _currentSpawnTime = 0f;
        GetRandomMaxTime();
    }
    private void GetRandomMaxTime()
    {
        _maxSpawnTime = Random.Range(_min, _max);
    }

    private void IncreaseIndex()
    {
        if(CanIncrease)
        {
            _index++;
        }
    }
}
}

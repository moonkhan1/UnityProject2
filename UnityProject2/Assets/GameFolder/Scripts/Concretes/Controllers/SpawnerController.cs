using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityProject2.Controllers{
public class SpawnerController : MonoBehaviour
{
    [SerializeField] EnemyController _enemyPrefeb;
    [Range(0.2f,5f)][SerializeField] float _min = 0.2f;
    [Range(6f,15f)][SerializeField] float _max = 15f;
    float _maxSpawnTime;
    float _currentSpawnTime = 0f;

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
    }
    private void Spawn()
    {
        // Dusmenin Spawn olmasi ve birdefelik Hierarchy'de Spawn oldugu Spawnerin childe'si kimi spawn olmasi
        EnemyController newEnemy = Instantiate(_enemyPrefeb,transform.position, transform.rotation);
        newEnemy.transform.parent = this.transform;

        _currentSpawnTime = 0f;
        GetRandomMaxTime();
    }
    private void GetRandomMaxTime()
    {
        _maxSpawnTime = Random.Range(_min, _max);
    }
}
}

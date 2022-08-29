using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Controllers;
using UnityProject2.Abstracts.Utilities;
using UnityProject2.Enums;

namespace UnityProject2.Managers{
public class EnemyManager : SingletonMonoBehaviorObject<EnemyManager>
{
    // Birden cox Enemy obyektini elave eded bilmek ucun bu deyiseni List edirik
    
    [SerializeField] float _addDelayTime = 50f;
    [SerializeField] EnemyController[] _enemyPrefebs;

    Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum,Queue<EnemyController>>(); // Enemy Pool

    public float AddDelayTime => _addDelayTime;

    public int Count => _enemyPrefebs.Length;

    private void Awake() {
        SingletonThisObject(this);
    }
    private void Start() {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < _enemyPrefebs.Length; i++)
        {
            Queue<EnemyController> enemyControllers = new Queue<EnemyController>();
            for (int j = 0; j < 10; j++)
            {
                EnemyController newEnemy = Instantiate(_enemyPrefebs[i]);
                newEnemy.gameObject.SetActive(false);
                newEnemy.transform.parent = this.transform;
                enemyControllers.Enqueue(newEnemy); // Enemy Poola elave edirik
            }    
            _enemies.Add((EnemyEnum)i,enemyControllers);
        }
        
    }
    public void SetPool(EnemyController enemyController)
    {
        enemyController.gameObject.SetActive(false);
        enemyController.transform.parent = this.transform;

        Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyType];
        enemyControllers.Enqueue(enemyController);
        
    }
    public EnemyController GetPool(EnemyEnum enemyType)
    {
        Queue<EnemyController> enemyControllers = _enemies[enemyType];
        if(enemyControllers.Count == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                EnemyController newEnemy = Instantiate(_enemyPrefebs[(int) enemyType]);
                enemyControllers.Enqueue(newEnemy);
            }
        }
        return enemyControllers.Dequeue();
    }
}
}

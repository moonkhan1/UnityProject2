using System.IO;
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
    
    [SerializeField] EnemyController[] _enemyPrefebs;

    Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum,Queue<EnemyController>>(); // Enemy Pool


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
            Queue<EnemyController> enemyController = new Queue<EnemyController>();
            for (int j = 0; j < 10; j++)
            {
                EnemyController newEnemy = Instantiate(_enemyPrefebs[i]);
                newEnemy.gameObject.SetActive(false);
                newEnemy.transform.parent = this.transform;
                _enemies.Enqueue(newEnemy); // Enemy Poola elave edirik
                _enemies.Enqueue(newEnemy);
            }    
            _enemies.Add((EnemyEnum)i,enemyController);
        }
        
    }
    public void SetPool(EnemyController enemyController)
    {
        enemyController.gameObject.SetActive(false);
        enemyController.transform.parent = this.transform;
        _enemies.Enqueue(enemyController);
        
    }
    public EnemyController GetPool()
    {
        if(_enemies.Count == 0)
        {
            InitializePool();
        }
        return _enemies.Dequeue();
    }
}
}

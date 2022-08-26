using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Controllers;
using UnityProject2.Abstracts.Utilities;

namespace UnityProject2.Managers{
public class EnemyManager : SingletonMonoBehaviorObject<EnemyManager>
{

    [SerializeField] EnemyController _enemyPrefeb;
    Queue<EnemyController> _enemies = new Queue<EnemyController>(); // Enemy Pool

    private void Awake() {
        SingletonThisObject(this);
    }
    private void Start() {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < 10; i++)
        {
            EnemyController newEnemy = Instantiate(_enemyPrefeb);
            newEnemy.gameObject.SetActive(false);
            newEnemy.transform.parent = this.transform;
            _enemies.Enqueue(newEnemy); // Enemy Poola elave edirik
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

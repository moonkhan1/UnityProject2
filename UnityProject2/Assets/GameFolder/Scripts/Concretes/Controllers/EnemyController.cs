using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Movements;
using UnityProject2.Managers;
// using UnityProject2.Controllers;
using UnityProject2.Abstracts.Controllers;
using UnityProject2.Enums;

namespace UnityProject2.Controllers{
public class EnemyController : MyCharacterController, I_EntityController
{

    [SerializeField] float _maxLifeTime = 10f;
    [SerializeField] EnemyEnum _enemyEnum; 

    VerticalMover _mover;
    float _currentLifeTime = 0f;

    
    public EnemyEnum EnemyType =>_enemyEnum;

    private void Awake() {
        _mover = new VerticalMover(this);
    }

    private void Update() {
        _currentLifeTime += Time.deltaTime;
        if(_currentLifeTime > _maxLifeTime)
        {
            _currentLifeTime = 0f;
            KillYourself();
        }
    }

    private void FixedUpdate() {
        _mover.FixedTick();
    }

    void KillYourself(){
        EnemyManager.Instance.SetPool(this);
        // Destroy(this.gameObject);
    }
}
}
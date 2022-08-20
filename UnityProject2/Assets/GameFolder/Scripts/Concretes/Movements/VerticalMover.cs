using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Controllers;

namespace UnityProject2.Movements{
public class VerticalMover 
{

    float _moveSpeed;
    
        EnemyController _enemyController;

        public VerticalMover(EnemyController enemyController)
        {
            _enemyController=enemyController;
            _moveSpeed = _enemyController.MoveSpeed;
        }

    public void FixedTick(float vertical = 1f)
    {
        _enemyController.transform.Translate(Vector3.forward * vertical * _moveSpeed * Time.deltaTime);
    }
}

}

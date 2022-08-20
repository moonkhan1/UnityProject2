using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Movements;

namespace UnityProject2.Controllers{
public class EnemyController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10f;
    VerticalMover _mover;

    public float MoveSpeed => _moveSpeed;

    private void Awake() {
        _mover = new VerticalMover(this);
    }

    private void FixedUpdate() {
        _mover.FixedTick();
    }
}
}
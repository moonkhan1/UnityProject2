using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Movements;

namespace UnityProject2.Controllers{
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _horizontalDirection = 0f;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] float _jumpForce = 300f;
    [SerializeField] bool _isJump;
    HorizontalMove _horizontalMove;
    JumpWithRigidBody _jump;

    private void Awake() {
        _horizontalMove = new HorizontalMove(this);
        _jump = new JumpWithRigidBody(this);
    }

    private void FixedUpdate() {
        _horizontalMove.TickFixer(_horizontalDirection,_moveSpeed);
        
        if(_isJump)
        {
            _jump.TickFixer(_jumpForce);
            
        }
        _isJump=false;
    }
}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Movements;
using UnityEngine.InputSystem;
using UnityProject2.Inputs;
using UnityProject2.Abstracts.I_InputReader;

namespace UnityProject2.Controllers{
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] float _jumpForce = 300f;
    [SerializeField] bool _isJump;

    HorizontalMove _horizontalMove;
    JumpWithRigidBody _jump;
    I_InputReader _input;
    float _horizontal;

    private void Awake() {
        _horizontalMove = new HorizontalMove(this);
        _jump = new JumpWithRigidBody(this);
        _input = new InputReader(GetComponent<PlayerInput>());
    }

    private void Update() {
        _horizontal = _input.Horizontal;
    }
    private void FixedUpdate() {
        _horizontalMove.TickFixer(_horizontal,_moveSpeed);
        
        if(_isJump)
        {
            _jump.TickFixer(_jumpForce);
            
        }
        _isJump=false;
    }
}
}
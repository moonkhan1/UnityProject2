using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Movements;
using UnityEngine.InputSystem;
using UnityProject2.Inputs;
using UnityProject2.Abstracts.I_InputReader;
using UnityProject2.Managers;
using UnityProject2.Abstracts.Controllers;
using UnityProject2.Abstracts.Movements;

namespace UnityProject2.Controllers{
public class PlayerController : MyCharacterController, I_EntityController
{
    
    [SerializeField] float _jumpForce = 300f;

    İ_Mover _mover;
    I_Jump _jump;
    I_InputReader _input;
    float _horizontal;
    bool _isJump;
    bool _isDead = false; // Toqqusduqdan sonra hec bir input almasin

    

    private void Awake() {
        _mover = new HorizontalMove(this);
        _jump = new JumpWithRigidBody(this);
        _input = new InputReader(GetComponent<PlayerInput>());
    }

    private void Update() {

        if(_isDead) return;
        _horizontal = _input.Horizontal;

        if(_input.isJump) 
        {
            _isJump = true;
        }
    }
    private void FixedUpdate() {
        _mover.FixedTick(_horizontal);
        
        if(_isJump)
        {
            _jump.FixedTick(_jumpForce);
            
        }
        _isJump=false;
    }

    private void OnCollisionEnter(Collision other) 
    {
        I_EntityController entityController = other.collider.GetComponent<I_EntityController>();

        if(entityController != null)
        {
            _isDead = true;
            GameManager.Instance.StopGame();   
        }
    }
    // private void OnTriggerEnter(Collider other) {
    //     EnemyController enemyController = other.GetComponent<EnemyController>();

    //     if(enemyController != null)
    //     {
    //         GameManager.Instance.StopGame();   
    //     }
    // }
}
}
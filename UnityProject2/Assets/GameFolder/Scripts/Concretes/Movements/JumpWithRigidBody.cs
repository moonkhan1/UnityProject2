using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Controllers;
using UnityProject2.Abstracts.Movements;
public class JumpWithRigidBody : I_Jump
{
    Rigidbody _rigidBody;

    public bool CanJump =>_rigidBody.velocity.y !=0f;
    public JumpWithRigidBody(PlayerController playerController)
    {
        _rigidBody = playerController.GetComponent<Rigidbody>();
    }
    
    public void FixedTick(float jumpForce)
    {
        if(CanJump) return;

        _rigidBody.velocity = Vector3.zero;
        _rigidBody.AddForce(Vector3.up * Time.deltaTime * jumpForce);
    }
}

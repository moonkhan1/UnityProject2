using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Controllers;
public class JumpWithRigidBody 
{
    private Rigidbody _rigidBody;

    public JumpWithRigidBody(PlayerController playerController)
    {
        _rigidBody = playerController.GetComponent<Rigidbody>();
    }
    
    public void TickFixer(float jumpForce)
    {
        if(_rigidBody.velocity.y !=0) return;

        _rigidBody.velocity = Vector3.zero;
        _rigidBody.AddForce(Vector3.up * Time.deltaTime * jumpForce);
    }
}

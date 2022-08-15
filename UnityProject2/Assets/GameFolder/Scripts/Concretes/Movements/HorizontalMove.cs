using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Controllers;

namespace UnityProject2.Movements{
public class HorizontalMove 
{
    PlayerController _playerController;

    public HorizontalMove(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public void TickFixer(float horizontal, float moverSpeed)
    {
        if(horizontal == 0f) return;

        _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * moverSpeed);
    }
}
}
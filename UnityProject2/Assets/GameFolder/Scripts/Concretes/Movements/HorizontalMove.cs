using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Controllers;

namespace UnityProject2.Movements{
public class HorizontalMove 
{
    PlayerController _playerController;
    float _moveSpeed;
    float _moveBoundry;

    public HorizontalMove(PlayerController playerController)
    {
        _playerController = playerController;
        _moveSpeed = _playerController.MoveSpeed;
        _moveBoundry = _playerController.MoveBoundry;
    }
    public void TickFixer(float horizontal)
    {
        if(horizontal == 0f) return;

        _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _moveSpeed);
        // Playerin platformadan dusmeyib mueyyen serhedler daxilinde qalmasi ucun
        float xBoundry = Mathf.Clamp(_playerController.transform.position.x, -_moveBoundry,_moveBoundry);
        // Player serhedlerden cixarsa yeni serhed teyin edirik
        _playerController.transform.position = new Vector3(xBoundry, _playerController.transform.position.y,20f);
    }
}
}
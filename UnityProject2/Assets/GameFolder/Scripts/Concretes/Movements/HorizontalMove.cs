using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Abstracts.Movements;
using UnityProject2.Abstracts.Controllers;

namespace UnityProject2.Movements{
public class HorizontalMove : İ_Mover
{
    I_EntityController _playerController;
    float _moveSpeed;
    float _moveBoundary;

    public HorizontalMove(I_EntityController entityController)
    {
        _playerController = entityController;
        _moveSpeed = _playerController.MoveSpeed;
        _moveBoundary = _playerController.MoveBoundary;
    }
    public void FixedTick(float horizontal)
    {
        if(horizontal == 0f) return;

        _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _moveSpeed);
        // Playerin platformadan dusmeyib mueyyen serhedler daxilinde qalmasi ucun
        float xBoundry = Mathf.Clamp(_playerController.transform.position.x, -_moveBoundary,_moveBoundary);
        // Player serhedlerden cixarsa yeni serhed teyin edirik
        _playerController.transform.position = new Vector3(xBoundry, _playerController.transform.position.y,20f);
    }
}
}
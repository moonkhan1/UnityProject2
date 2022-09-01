using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Abstracts.Movements;
using UnityProject2.Abstracts.Controllers;

namespace UnityProject2.Movements{
public class HorizontalMove : İ_Mover
{
    I_EntityController _entityController;
    float _moveSpeed;
    float _moveBoundary;

    public HorizontalMove(I_EntityController entityController)
    {
        _entityController = entityController;
    }
    public void FixedTick(float horizontal)
    {
        if(horizontal == 0f) return;

        _entityController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _entityController.MoveSpeed);
        // Playerin platformadan dusmeyib mueyyen serhedler daxilinde qalmasi ucun
        float xBoundry = Mathf.Clamp(_entityController.transform.position.x, -_entityController.MoveBoundary,_entityController.MoveBoundary);
        // Player serhedlerden cixarsa yeni serhed teyin edirik
        _entityController.transform.position = new Vector3(xBoundry, _entityController.transform.position.y,20f);
    }
}
}
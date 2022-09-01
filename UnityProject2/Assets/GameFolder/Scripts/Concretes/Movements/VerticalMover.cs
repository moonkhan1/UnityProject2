using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Controllers;
using UnityProject2.Abstracts.Movements;
using UnityProject2.Abstracts.Controllers;

namespace UnityProject2.Movements{
public class VerticalMover : İ_Mover
{

    
        I_EntityController _entityController;

        public VerticalMover(I_EntityController entityController)
        {
            _entityController=entityController;
        }

    public void FixedTick(float vertical = 1f)
    {
        _entityController.transform.Translate(Vector3.forward * vertical * _entityController.MoveSpeed * Time.deltaTime);
    }
}

}

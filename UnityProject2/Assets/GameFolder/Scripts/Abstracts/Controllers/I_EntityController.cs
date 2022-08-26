using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject2.Abstracts.Controllers{
public interface I_EntityController 
{
    Transform transform{get;}
    float MoveSpeed { get; }
    float MoveBoundary { get;} 
}
}

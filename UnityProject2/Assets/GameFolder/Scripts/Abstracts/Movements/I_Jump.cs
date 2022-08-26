using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject2.Abstracts.Movements{
public interface I_Jump 
{
    void FixedTick(float jumpForce);    
}
}
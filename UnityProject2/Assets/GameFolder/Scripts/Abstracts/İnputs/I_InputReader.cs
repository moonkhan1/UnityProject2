using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityProject2.Abstracts.I_InputReader{
public interface I_InputReader // Interfacelerin access modifierleri ola bilmez
{
     float Horizontal { get; }
     bool isJump {get;}
}
}

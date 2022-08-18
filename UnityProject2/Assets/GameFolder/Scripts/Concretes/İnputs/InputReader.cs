using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityProject2.Abstracts.I_InputReader;

namespace UnityProject2.Inputs
{
public class InputReader : I_InputReader
{
    
    PlayerInput _playerinput;

    public float Horizontal {get;private set;}
    public InputReader(PlayerInput playerInput)
    {
        _playerinput=playerInput;
        _playerinput.currentActionMap.actions[0].performed += OnHorizontalMove; 
    }
    void OnHorizontalMove(InputAction.CallbackContext context)
    {
        Horizontal = context.ReadValue<float>();
    }
    
}
}

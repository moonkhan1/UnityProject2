using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Managers;

namespace UnityProject2.Concretes.Uİs{
public class MenuPanel : MonoBehaviour
{
    public void StartButton()
    {
        GameManager.Instance.LoadScene();
    }

    public void ExitButton()
    {
        GameManager.Instance.ExitGame();
    }
}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Managers;

namespace UnityProject2.Concretes.Uİs{
public class MenuPanel : MonoBehaviour
{
    public void SelectandStartButton(int index)
    {
        GameManager.Instance.DifficultyIndex = index;
        GameManager.Instance.LoadScene("Game");
    }

    public void ExitButton()
    {
        GameManager.Instance.ExitGame();
    }
}
}
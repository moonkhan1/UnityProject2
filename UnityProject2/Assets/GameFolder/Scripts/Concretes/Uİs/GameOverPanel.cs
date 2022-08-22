using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Managers;

namespace UnityProject2.Uİs{
public class GameOverPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public void TryAgainButton()
    {
        GameManager.Instance.LoadScene("Game");
    }

    // Update is called once per frame
    public void ExitButton()
    {
        GameManager.Instance.LoadScene("Menu");
    }
}

}
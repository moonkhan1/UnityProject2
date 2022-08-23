using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Managers;

namespace UnityProject2.Uİs{
public class GameCanva : MonoBehaviour
{
    [SerializeField] GameOverPanel _gameOverPanel;

    private void Awake() {
        _gameOverPanel.gameObject.SetActive(false);
    }

    private void OnEnable() {
        GameManager.Instance.OnGameStop += HandleOnGameStop;
    }
    private void OnDisable() {
        GameManager.Instance.OnGameStop -= HandleOnGameStop;
    }

    private void HandleOnGameStop()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }
}
}
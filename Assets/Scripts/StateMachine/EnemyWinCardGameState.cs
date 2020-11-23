using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyWinCardGameState : CardGameState
{
    public Text enemyWinText;
    public GameObject overlay;
    public Button newGameButton;

    public override void Enter()
    {
        Debug.Log("Game over: ...Enter");
        overlay.gameObject.SetActive(true);
        newGameButton.gameObject.SetActive(true);
        enemyWinText.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        Debug.Log("Game over: Exit...");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

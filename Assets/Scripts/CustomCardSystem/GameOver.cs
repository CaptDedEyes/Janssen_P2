using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text playerWinText;
    public Text enemyWinText;
    public GameObject overlay;
    public Button playAgainButton;
    public AudioClip playerWinsSound;
    public AudioClip enemyWinsSound;

    public void PlayerWins()
    {
        Debug.Log("Game over, Player Wins!");
        overlay.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
        playerWinText.gameObject.SetActive(true);
        AudioHelper.PlayClip2D(playerWinsSound, 1f);
    }

    public void EnemyWins()
    {
        Debug.Log("Game over, Enemy Wins!");
        overlay.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
        enemyWinText.gameObject.SetActive(true);
        AudioHelper.PlayClip2D(enemyWinsSound, 1f);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

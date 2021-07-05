using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Canvas gameOverCanvas;

    [SerializeField]
    private Text currentScore, bestScore;

    private ScoreCounter scoreCounter;

    private void Awake()
    {
        scoreCounter = GetComponent<ScoreCounter>();
    }

    public void GameOverShowPanel()
    {
        // scoreCounter.CanCountScore = false;
        Time.timeScale = 0f;

        gameOverCanvas.enabled = true;

        DisplayScore();

        CheckToUnlockNewCharacters(scoreCounter.GetScore());
    }

    private void DisplayScore()
    {
        currentScore.text = "Score: " + scoreCounter.GetScore();
    }

    private void CheckToUnlockNewCharacters(int score)
	{

	}

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE_NAME);
    }
}
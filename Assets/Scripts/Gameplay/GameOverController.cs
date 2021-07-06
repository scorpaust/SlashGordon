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
        SoundManager.instance.PlayGameOverSound();

        // scoreCounter.CanCountScore = false;
        Time.timeScale = 0f;

        gameOverCanvas.enabled = true;

        DisplayScore();

        CheckToUnlockNewCharacters(scoreCounter.GetScore());
    }

    private void DisplayScore()
    {
        int highScore = DataManager.GetData(TagManager.HIGHSCORE_DATA);

        if (scoreCounter.GetScore() > highScore)
		{
            DataManager.SaveData(TagManager.HIGHSCORE_DATA, scoreCounter.GetScore());
		}

        currentScore.text = "Score: " + scoreCounter.GetScore();

        bestScore.text = "Best: " + DataManager.GetData(TagManager.HIGHSCORE_DATA) + "m";
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
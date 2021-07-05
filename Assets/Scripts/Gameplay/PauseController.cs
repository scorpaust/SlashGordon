﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    public void PauseGame()
	{
		Time.timeScale = 0f;

		pausePanel.SetActive(true);
	}

    public void ResumeGame()
	{
		Time.timeScale = 1f;

		pausePanel.SetActive(false);
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

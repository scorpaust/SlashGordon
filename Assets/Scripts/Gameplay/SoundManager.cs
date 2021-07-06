using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

	[SerializeField]
	private AudioClip bgMusic, mainMenuMusic, playerAttackSfx, playerJumpSfx, playerDeathSfx, enemyAttackSfx, enemyDeathSfx, collectableSfx, destroyObstacleSfx;

	[SerializeField]
    private AudioSource bgAudio, gameOverAudio;

	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	public void PlayBGMusic(bool gameplay)
	{
		if (gameplay)
		{
			bgAudio.clip = bgMusic;

		} 
		else
		{
			bgAudio.clip = mainMenuMusic;
		}

		bgAudio.Play();
	}

	public void TurnOffBGMusic()
	{
		bgAudio.Stop();
	}

	public void PlayGameOverSound()
	{
		gameOverAudio.Play();
	}

	public void PlayPlayerAttackSound()
	{
		AudioSource.PlayClipAtPoint(playerAttackSfx, transform.position);
	}

	public void PlayPlayerJumpSound()
	{
		AudioSource.PlayClipAtPoint(playerJumpSfx, transform.position);
	}

	public void PlayPlayerDeathSound()
	{
		AudioSource.PlayClipAtPoint(playerDeathSfx, transform.position);
	}

	public void PlaEnemyAttackSound()
	{
		AudioSource.PlayClipAtPoint(enemyAttackSfx, transform.position);
	}

	public void PlayEnemyDeathSound()
	{
		AudioSource.PlayClipAtPoint(enemyDeathSfx, transform.position);
	}

	public void PlayCollectableSound()
	{
		AudioSource.PlayClipAtPoint(collectableSfx, transform.position);
	}

	public void PlayDestroyObstacleSound()
	{
		AudioSource.PlayClipAtPoint(destroyObstacleSfx, transform.position);
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
	{
		if (scene.name == TagManager.GAMEPLAY_SCENE_NAME)
		{
			if (DataManager.GetData(TagManager.MUSIC_DATA) == 1)
				PlayBGMusic(true);
		}
		else
		{
			if (DataManager.GetData(TagManager.MUSIC_DATA) == 1)
				PlayBGMusic(false);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector]
    public int selectedChar = 0;

    [SerializeField]
    private int char2UnlockScore = 100, char3UnlockScore = 300;

    [SerializeField]
    private GameObject[] players;

	private void OnEnable()
	{
        SceneManager.sceneLoaded += OnSceneLoaded;
	}

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

	private void Start()
	{
        int gameData = DataManager.GetData(TagManager.DATA_INITIALIZED);

        if (gameData == 0)
		{
            selectedChar = 0;

            DataManager.SaveData(TagManager.SELECTED_CHARACTER_DATA, selectedChar);

            DataManager.SaveData(TagManager.HIGHSCORE_DATA, 0);

            DataManager.SaveData(TagManager.CHARACTER_DATA + "0", 1);

            DataManager.SaveData(TagManager.CHARACTER_DATA + "1", 0);

            DataManager.SaveData(TagManager.CHARACTER_DATA + "2", 0);

            DataManager.SaveData(TagManager.MUSIC_DATA, 1);

            DataManager.SaveData(TagManager.DATA_INITIALIZED, 1);
        }
        else if (gameData == 1)
		{
            selectedChar = DataManager.GetData(TagManager.SELECTED_CHARACTER_DATA);
		}
	}

	private void OnDisable()
	{
        SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
	{
        if (scene.name == TagManager.GAMEPLAY_SCENE_NAME)
		{

            Instantiate(players[selectedChar]);

            Camera.main.GetComponent<CameraFollow>().FindPlayerRef();
		}
	}

    public void CheckToUnlockCharacter(int score)
	{
        if (score > char3UnlockScore)
		{
            DataManager.SaveData(TagManager.CHARACTER_DATA + "1", 1);
            DataManager.SaveData(TagManager.CHARACTER_DATA + "2", 1);
        }
        else if (score > char2UnlockScore)
		{
            DataManager.SaveData(TagManager.CHARACTER_DATA + "1", 1);
        }
	}
}

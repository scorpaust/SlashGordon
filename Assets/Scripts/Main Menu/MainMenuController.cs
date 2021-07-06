using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject characterSelectMenuPanel;

    [SerializeField]
    private Text highscoreTxt;

    [SerializeField]
    private Image musicImg;

    [SerializeField]
    private Sprite musicOn, musicOff;

    private CharacterSelectMenu charSelectMenu;

	private void Awake()
	{
		if (DataManager.GetData(TagManager.MUSIC_DATA) == 1)
		{
            musicImg.sprite = musicOn;
		}
        else
		{
            musicImg.sprite = musicOff;
		}
	}

	private void Start()
	{
        highscoreTxt.text = "Highscore: " + DataManager.GetData(TagManager.HIGHSCORE_DATA) + "m";

        charSelectMenu = GetComponent<CharacterSelectMenu>();
	}

	public void ToggleCharacterSelectMenu(bool open)
	{
        if (open)
            charSelectMenu.InitializeCharacterMenu();

        characterSelectMenuPanel.SetActive(open);
    }

    public void SelectCharacter()
	{
        int selectedChar = int.Parse(EventSystem.current.currentSelectedGameObject.name);

        GameplayController.instance.selectedChar = selectedChar;

        DataManager.SaveData(TagManager.SELECTED_CHARACTER_DATA, selectedChar);

        charSelectMenu.InitializeCharacterMenu();
	}

    public void PlayGame()
	{
        SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
	}

    public void TurnMusicOnOrOff()
	{
        if (DataManager.GetData(TagManager.MUSIC_DATA) == 1)
		{
            DataManager.SaveData(TagManager.MUSIC_DATA, 0);

            SoundManager.instance.TurnOffBGMusic();

            musicImg.sprite = musicOff;
        }
        else
		{
            DataManager.SaveData(TagManager.MUSIC_DATA, 1);

            SoundManager.instance.PlayBGMusic(false);

            musicImg.sprite = musicOn;
        }
	}
}

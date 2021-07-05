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

    private CharacterSelectMenu charSelectMenu;

	private void Start()
	{
        highscoreTxt.text = "0m";

        charSelectMenu = GetComponent<CharacterSelectMenu>();
	}

	public void ToggleCharacterSelectMenu(bool open)
	{
        characterSelectMenuPanel.SetActive(open);
    }

    public void SelectCharacter()
	{
        int selectedChar = int.Parse(EventSystem.current.currentSelectedGameObject.name);
	}

    public void PlayGame()
	{
        SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
	}
}

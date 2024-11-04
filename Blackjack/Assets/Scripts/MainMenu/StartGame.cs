using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class StartGame : MonoBehaviour
{
    public Button startMenu;
    public Button quitButton;
    public Button startButton;
    public Button closeButton;
    public GameObject scene;
    public static string displayName = "Player";
    public static int botNum = 0;
    public static string botNumString;
    public InputField numberOfBots;
    public InputField playerName;

    void Start()
    {
        // Assign functionality to menu
        startButton.onClick.AddListener(GameStart);
        quitButton.onClick.AddListener(QuitGame);
        startMenu.onClick.AddListener(StartMenu);
        closeButton.onClick.AddListener(CloseMenu);
    }

    public void CloseMenu()
    {
        scene.SetActive(false);
    }

    public void StartMenu()
    {
        scene.SetActive(true);
    }

    public void GameStart()
    {
        displayName = playerName.text;

        botNumString = numberOfBots.text;
        botNum = int.Parse(botNumString);

        if (botNum > 5)
        {
            botNum = 5;
        }
        else if (botNum < 0)
        {
            botNum = 0;
        }

        Debug.Log("Player name is: " +  displayName);
        Debug.Log("Number of bots is: " + botNum);

        DisplayPlayerName.displayName = displayName;
        BotScript.botNum = botNum;

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

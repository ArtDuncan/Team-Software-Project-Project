using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{

    public Button open;
    public Button close;
    public GameObject scene;
    public Button quitButton;
    public Button menuButton;

    // Start is called before the first frame update
    void Start()
    {
        open.onClick.AddListener(openMethod);
        close.onClick.AddListener(closeMethod);
        menuButton.onClick.AddListener(menu);
        quitButton.onClick.AddListener(quit);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void openMethod()
    {
        scene.SetActive(true);
    }

    public void closeMethod()
    {
        scene.SetActive(false);
    }
}

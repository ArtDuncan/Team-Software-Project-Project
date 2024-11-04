using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class DisplayName : MonoBehaviour
{
    public Text displayNameText;
    public static string name;

    void Start()
    {
        name = StartGame.displayName;

        if (displayNameText != null)
        {
            // Set the text to the static displayName from StartGame
            displayNameText.text = "" + name;
        }
        else
        {
            Debug.LogError("DisplayNameText is not assigned in the inspector!");
        }
    }
}

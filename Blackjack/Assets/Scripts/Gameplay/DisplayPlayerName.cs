using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class DisplayPlayerName : MonoBehaviour
{
    public Text textDisplay;
    public static string displayName;

    void Start()
    {
        textDisplay.text = displayName;
    }
}

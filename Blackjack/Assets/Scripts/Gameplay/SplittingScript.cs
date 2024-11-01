using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class SplittingScript : MonoBehaviour
{
    //option to bet split pairs
    public Button split;
    //enable btton to show up if condition is true
    public GameObject splitPanel;

   
    public void initiateStart(GameObject card1, GameObject card2)
    {
        splitPanel.SetActive(true);
        split.onClick.AddListener(() => activateSplit());
    }

    // Update is called once per frame
    void activateSplit()
    {
        
    }
}

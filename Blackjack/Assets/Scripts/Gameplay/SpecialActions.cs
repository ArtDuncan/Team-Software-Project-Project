using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class SpecialActions : MonoBehaviour
{
    //option to bet split pairs
    public Button split;
    public Button dd;
    public Button insurance;
    //enable btton to show up if condition is true
    public GameObject splitPanel;
    public GameObject ddPanel;
    public GameObject insurancePanel;
   
    public void initiateSplit(GameObject card1, GameObject card2)
    {
        splitPanel.SetActive(true);
        split.onClick.AddListener(() => activateSplit());
    }

    public void initiateDD(GameObject card1, GameObject card2)
    {
        ddPanel.SetActive(true);
        dd.onClick.AddListener(() => activateSplit());
    }

    public void initiateInsurance(GameObject card1, GameObject card2)
    {
        insurancePanel.SetActive(true);
        insurance.onClick.AddListener(() => activateSplit());
    }

    // Update is called once per frame
    void activateSplit()
    {
        
    }
}

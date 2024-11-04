using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Game buttons
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;

    // Access to player and dealer script
    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    void Start()
    {
        // Listeners
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());

    }

    private void DealClicked()
    {
        playerScript.StartHand();
        dealerScript.StartHand();
    }

    private void HitClicked()
    {

    }

    private void StandClicked()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

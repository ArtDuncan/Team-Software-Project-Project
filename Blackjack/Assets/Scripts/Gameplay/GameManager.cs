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
    public PlayerScript bot1Script;
    public PlayerScript bot2Script;
    public PlayerScript bot3Script;
    public PlayerScript bot4Script;
    public PlayerScript bot5Script;

    void Start()
    {
        // Listeners
        dealBtn.interactable = false;
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());

    }

    private void DealClicked()
    {
        playerScript.StartHand();
        dealerScript.StartHand();
        bot1Script.StartHand();
        bot2Script.StartHand();
        bot3Script.StartHand();
        bot4Script.StartHand();
        bot5Script.StartHand();
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

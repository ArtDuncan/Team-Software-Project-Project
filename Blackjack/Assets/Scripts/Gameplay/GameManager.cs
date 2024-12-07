using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Game buttons
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Text standBtnText;

    private int standClicks = 0;

    // Access to player and dealer script
    public PlayerScript playerScript;
    public PlayerScript dealerScript;
    public PlayerScript bot1Script;
    public PlayerScript bot2Script;
    public PlayerScript bot3Script;
    public PlayerScript bot4Script;
    public PlayerScript bot5Script;

    public Text mainText;
    public string playerName = StartGame.displayName;

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
        hitBtn.interactable = true;
        standBtn.interactable = true;
        playerScript.StartHand();
        dealerScript.StartHand();
        switch(StartGame.botNum)
        {
            case 0:
                break;
            case 1: 
                bot1Script.StartHand();
                break;
            case 2: 
                bot1Script.StartHand();
                bot2Script.StartHand();
                break;
            case 3: 
                bot1Script.StartHand();
                bot2Script.StartHand();
                bot3Script.StartHand();
                break;
            case 4: 
                bot1Script.StartHand();
                bot2Script.StartHand();
                bot3Script.StartHand();
                bot4Script.StartHand();
                break;
            case 5: 
                bot1Script.StartHand();
                bot2Script.StartHand();
                bot3Script.StartHand();
                bot4Script.StartHand();
                bot5Script.StartHand();
                break;
        }
    }

    private void HitClicked()
    {
        playerScript.Hit();
    }

    private void StandClicked()
    {
        standClicks++;
        if (standClicks > 1)
        {
            Debug.Log("End function");
        }

        HitDealer();
        standBtnText.text = "Call";
    }

    private void HitDealer()
    {
        while(dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
        }
    }

    // Check for winner
    void RoundOver()
    {
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = playerScript.handValue == 21;

        // Continues round if none of these happen
        if (standClicks < 2 && !playerBust && !dealerBust && !player21 && !dealer21) return;
        bool roundOver = true;

        // Both bust
        if (playerBust && dealerBust) 
        {
            mainText.text = "All bust: Bets returned";
            //Betting.currentMoney += Betting.betAmount;
        }
        // If just player bust or dealer larger hand
        else if (playerBust || dealerScript.handValue > playerScript.handValue)
        {
            mainText.text = "Dealer Wins!";
        }
        // If dealer busts or player larger hand
        else if (dealerBust || dealerScript.handValue < playerScript.handValue)
        {
            mainText.text = playerName + " Wins!";
            //Betting.currentMoney += Betting.betAmount * 2;
        }
        // Check for tie
        else if (playerScript.handValue == dealerScript.handValue)
        {
            mainText.text = "Push: Bets returned";
            //Betting.currentMoney += Betting.betAmount;
        }
        else
        {
            roundOver = false;
        }
        // Set up next round
        if(roundOver)
        {
           // betButton.interactable = false;
           // DealBtn.interactable = true;

        }
    }
}

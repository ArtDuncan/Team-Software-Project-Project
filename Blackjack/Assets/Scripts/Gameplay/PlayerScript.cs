using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // Same script for dealer and player

    // Access to other scripts
    public CardScript cardScript;
    public DeckScript deckScript;
    public SpecialActions specialActions;

    public GameObject thisActor;
    public GameObject playerInfo;
    public GameObject dealerInfo;
    public Betting betting;

    public Sprite back;

    // Total value of player and dealer hand
    public int handValue = 0;

    // Betting money
    private double playerMoney = 1000.00;

    // Array of card objects
    public GameObject[] hand = new GameObject[53];

    // Index of next card
    public int cardIndex = 0;

    // Track aces
    List<CardScript> aceList = new List<CardScript>();

    // array to keept track of what the player gets dealt
    public GameObject[] playerHand = new GameObject[11]; 

    public void StartHand()
    {
        GetCard();
        GetCard();
        betting.DealBtn.interactable = false;
    }

    public void DealerPlay()
    {
        while(handValue < 17)
        {
            Hit();
        }
        Stand();
    }

    public void Hit()
    {
        Debug.Log("Hit called. Current index is " + cardIndex + " and current user is " + thisActor);
        if(thisActor.tag != "Dealer")
        {
            specialActions.splitPanel.SetActive(false);
            specialActions.ddPanel.SetActive(false);
            specialActions.insurancePanel.SetActive(false);
        }
        GetCard();
        if(thisActor.tag == "Player")
        {
            if(handValue > 21)
            {
                betting.loseBet();
                return;
            }
        }
        if(thisActor.tag == "Dealer")
        {
            if(handValue > 21)
            {
                betting.winBet();
                return;
            }
        }
    }

    public void Stand()
    {
        if(thisActor.tag == "Player")
        {
            specialActions.splitPanel.SetActive(false);
            specialActions.ddPanel.SetActive(false);
            specialActions.insurancePanel.SetActive(false);
        }
        if(thisActor.tag == "Dealer")
        {
            if(handValue < playerInfo.GetComponent<PlayerScript>().handValue)
            {
                if(playerInfo.GetComponent<PlayerScript>().handValue == 21)
                {
                    betting.blackWinBet();
                    return;
                }
                betting.winBet();
                return;
            }
            if(handValue == playerInfo.GetComponent<PlayerScript>().handValue)
            {
                betting.drawBet();
                return;
            }
            if(handValue > playerInfo.GetComponent<PlayerScript>().handValue)
            {
                betting.loseBet();
                return;
            }
        }
        if(thisActor.tag == "Player")
        {
            dealerInfo.GetComponent<PlayerScript>().DealerPlay();
        }
    }

    // Add a hand to player and dealers hand
    public int GetCard()
    {

        // Get card
        int cardValue = deckScript.DealCard(playerHand[cardIndex].GetComponent<CardScript>());

        if(playerHand[0] != null && playerHand[1] != null && cardIndex < 2 && thisActor.tag == "Player")
        {
            Debug.Log("Current User is: " + thisActor);
            Debug.Log("Card 1 info: " + playerHand[0].GetComponent<CardScript>().getCardNum());
            Debug.Log("Card 2 info: " + playerHand[1].GetComponent<CardScript>().getCardNum());
            if (playerHand[0].GetComponent<CardScript>().getCardNum() == playerHand[1].GetComponent<CardScript>().getCardNum())
            {          
                specialActions.initiateSplit(playerHand[0], playerHand[1]);
            }

            int card1Val = playerHand[0].GetComponent<CardScript>().getCardNum();
            int card2Val = playerHand[1].GetComponent<CardScript>().getCardNum();
            if(card1Val > 10)
            {
                card1Val = 10;
            }
            if(card2Val > 10)
            {
                card2Val = 10;
            }
            if(card1Val + card2Val == 9 || card1Val + card2Val == 10 || card1Val + card2Val == 11)
            {
                specialActions.initiateDD(playerHand[0], playerHand[1]);
            }

            if(thisActor.tag == "Dealer" && playerHand[0].GetComponent<CardScript>().getCardNum() == 1)
            {
                specialActions.initiateInsurance(playerHand[0], playerHand[1]);
            }
        }
        if(cardIndex >= 2)
        {
            Debug.Log("Dealt card is: " + playerHand[cardIndex].GetComponent<CardScript>().getCardNum());
            playerHand[cardIndex].SetActive(true);
        }

        cardIndex++;
        if(cardValue > 10)
        {
            cardValue = 10;
        }
        handValue = handValue + cardValue;
        return handValue;
    }

    public void resetCards()
    {
        handValue = 0;
        for(int i = 2; i < cardIndex; i++)
        {
            playerHand[i].SetActive(false);
        }
        if(playerHand[0] != null && playerHand[1] != null)
        {
            playerHand[0].GetComponent<SpriteRenderer>().sprite = back;
            playerHand[1].GetComponent<SpriteRenderer>().sprite = back; 
        }
        cardIndex = 0;
        if(thisActor.tag == "Player")
        {
            dealerInfo.GetComponent<PlayerScript>().resetCards();
        }
    }

    //Getter for money
    public double getMoney()
    {
        return playerMoney;
    }

    //Allows money to be changed
    public void addMoney(double change)
    {
        playerMoney = playerMoney + change;
        return;
    }

}

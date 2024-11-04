using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Net;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Same script for dealer and player

    // Access to other scripts
    public CardScript cardScript;
    public DeckScript deckScript;
    public SpecialActions specialActions;

    public GameObject thisActor;

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

    // array to keept track of what the player gets deal
    public GameObject[] playerHand = new GameObject[11]; 

    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    // Add a hand to player and dealers hand
    public int GetCard()
    {
        if (cardIndex >= hand.Length)
        {
            return handValue; // Or handle it as needed
        }

        // Get card
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());

        // Show card
        hand[cardIndex].GetComponent<Renderer>().enabled = true;

        // Handle 1 or 11 for ace
        if (cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        
        //ensures that the cards going into players hand do not exceed
        if (cardIndex < playerHand.Length)
        {
            playerHand[cardIndex] = hand[cardIndex];
        }


        if(playerHand[0] != null && playerHand[1] != null)
        {
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

        cardIndex++;
        if(cardValue > 10)
        {
            cardValue = 10;
        }
        handValue = handValue + cardValue;
        return handValue;
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

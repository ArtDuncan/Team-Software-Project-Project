using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Same script for dealer and player

    // Access to other scripts
    public CardScript cardScript;
    public DeckScript deckScript;

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

        // Add card value to hand total
        handValue += cardValue;

        // Handle 1 or 11 for ace
        if (cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }

        cardIndex++;
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

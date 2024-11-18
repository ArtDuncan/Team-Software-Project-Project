using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeckScript : MonoBehaviour
{

    public Sprite[] cardSprites;
    int[] cardValues = new int[53];
    int currentIndex = 0;

    void Start()
    {
        GetCardValues();
    }

    void GetCardValues()
    {
        int num = 0;
        // Loop to assign card values
        for(int i = 0; i < cardSprites.Length; i++)
        {
            num = i;
            // Count up to amount of cards
            num %= 13;
            // if there is remauinder then remainder is value unless over ten use ten
            //if(num > 10 || num == 0)
            //{
            //    num = 10;
            //}
            if(num == 0)
            {
                num = 13;
            }
            cardValues[i] = num;
        }

        currentIndex = 1;
    }

    public void Shuffle()
    {
        // Array swap
        for(int i = cardSprites.Length - 1; i > 0; i--)
        {
            //test to see if split works
            //int j = 2;
            int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1;
            Sprite face = cardSprites[i];
            cardSprites[i] = cardSprites[j];
            cardSprites[j] = face;

            int value = cardValues[i];
            cardValues[i] = cardValues[j];
            cardValues[j] = value;

        }
    }

    // Set card script to sprite
    public int DealCard(CardScript cardScript)
    {
        Shuffle();
        Debug.Log("Current Index in deckScript is " + currentIndex);
        cardScript.SetSprite(cardSprites[currentIndex]);
        cardScript.SetNum(cardValues[currentIndex]);
        currentIndex++;

        return cardScript.getCardNum();

    } 

    // For CardScript, set card to back cover
    public Sprite GetCardBack()
    {
        return cardSprites[0];
    }
}

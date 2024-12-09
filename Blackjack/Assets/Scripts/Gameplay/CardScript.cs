using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    // Value of card
    public int value = 0;
    public int number = 0;

    //public DeckScript stupid;

    // Getter
    public int GetValueOfCard()
    {
        return value;
    }

    public int getCardNum()
    {
        return number;
    }

    // Setter for value
    public void SetNum(int newNum)
    {
        number = newNum;
        value = newNum;
        if(value > 10)
        {
            value = 10;
        }
    }
    
    public string GetSpriteName()
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }

    // Setter for sprite
    public void SetSprite(Sprite newSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void ResetCard()
    {
        Sprite back = GameObject.FindWithTag("Deck").GetComponent<DeckScript>().GetCardBack();
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;
    }


}

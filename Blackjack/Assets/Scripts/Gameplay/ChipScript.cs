using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipScript : MonoBehaviour
{
    //W = 1
    //R = 5
    //G = 25
    //Bla = 100
    //Blu = 500
    public int whiteChips;
    public int redChips;
    public int greenChips;
    public int blackChips;
    public int blueChips;

    public GameObject WhiteChips;
    public GameObject WhiteChips1;
    public GameObject WhiteChips2;
    public GameObject WhiteChips3;
    public GameObject WhiteChips4;
    public GameObject RedChips;
    public GameObject RedChips1;
    public GameObject RedChips2;
    public GameObject RedChips3;
    public GameObject RedChips4;
    public GameObject GreenChips;
    public GameObject GreenChips1;
    public GameObject GreenChips2;
    public GameObject GreenChips3;
    public GameObject GreenChips4;
    public GameObject BlackChips;
    public GameObject BlackChips1;
    public GameObject BlackChips2;
    public GameObject BlackChips3;
    public GameObject BlackChips4;
    public GameObject BlueChips;
    public GameObject BlueChips1;
    public GameObject BlueChips2;
    public GameObject BlueChips3;
    public GameObject BlueChips4;

    public void updateChips(double currentMoney)
    {
        BlueChips.SetActive(false);
        BlueChips1.SetActive(false);
        BlueChips2.SetActive(false);
        BlueChips3.SetActive(false);
        BlueChips4.SetActive(false);
        BlackChips.SetActive(false);
        BlackChips1.SetActive(false);
        BlackChips2.SetActive(false);
        BlackChips3.SetActive(false);
        BlackChips4.SetActive(false);
        GreenChips.SetActive(false);
        GreenChips1.SetActive(false);
        GreenChips2.SetActive(false);
        GreenChips3.SetActive(false);
        GreenChips4.SetActive(false);
        RedChips.SetActive(false);
        RedChips1.SetActive(false);
        RedChips2.SetActive(false);
        RedChips3.SetActive(false);
        RedChips4.SetActive(false);
        WhiteChips.SetActive(false);
        WhiteChips1.SetActive(false);
        WhiteChips2.SetActive(false);
        WhiteChips3.SetActive(false);
        WhiteChips4.SetActive(false);

        blueChips = (int)(currentMoney/500);
        currentMoney = currentMoney - blueChips * 500;
        blackChips = (int)(currentMoney/100);
        currentMoney = currentMoney - blackChips * 100;
        greenChips = (int)(currentMoney/25);
        currentMoney = currentMoney - greenChips * 25;
        redChips = (int)(currentMoney/5);
        currentMoney = currentMoney - redChips * 5;
        whiteChips = (int)(currentMoney/1);
        currentMoney = currentMoney - whiteChips * 1;
        if(blueChips >= 1)
        {
            BlueChips.SetActive(true);
        }
        if(blueChips >= 2)
        {
            BlueChips1.SetActive(true);
        }
        if(blueChips >= 3)
        {
            BlueChips2.SetActive(true);
        }
        if(blueChips >= 4)
        {
            BlueChips3.SetActive(true);
        }
        if(blueChips >= 5)
        {
            BlueChips4.SetActive(true);
        }
        if(blackChips >= 1)
        {
            BlackChips.SetActive(true);
        }
        if(blackChips >= 2)
        {
            BlackChips1.SetActive(true);
        }
        if(blackChips >= 3)
        {
            BlackChips2.SetActive(true);
        }
        if(blackChips >= 4)
        {
            BlackChips3.SetActive(true);
        }
        if(blackChips >= 5)
        {
            BlackChips4.SetActive(true);
        }
        if(greenChips >= 1)
        {
            GreenChips.SetActive(true);
        }
        if(greenChips >= 2)
        {
            GreenChips1.SetActive(true);
        }
        if(greenChips >= 3)
        {
            GreenChips2.SetActive(true);
        }
        if(greenChips >= 4)
        {
            GreenChips3.SetActive(true);
        }
        if(greenChips >= 5)
        {
            GreenChips4.SetActive(true);
        }
        if(redChips >= 1)
        {
            RedChips.SetActive(true);
        }
        if(redChips >= 2)
        {
            RedChips1.SetActive(true);
        }
        if(redChips >= 3)
        {
            RedChips2.SetActive(true);
        }
        if(redChips >= 4)
        {
            RedChips3.SetActive(true);
        }
        if(redChips >= 5)
        {
            RedChips4.SetActive(true);
        }
        if(whiteChips >= 1)
        {
            WhiteChips.SetActive(true);
        }
        if(whiteChips >= 2)
        {
            WhiteChips1.SetActive(true);
        }
        if(whiteChips >= 3)
        {
            WhiteChips2.SetActive(true);
        }
        if(whiteChips >= 4)
        {
            WhiteChips3.SetActive(true);
        }
        if(whiteChips >= 5)
        {
            WhiteChips4.SetActive(true);
        }
    }    
}

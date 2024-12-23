using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Betting : MonoBehaviour
{

    double currentMoney;
    public double betAmount = 0;
    private double slowBetAmount;
    public double insBet = 0;
    public PlayerScript data;
    public ChipScript chipScript;
    [SerializeField] private Text moneyDisplay;
    [SerializeField] private Text betDisplay;
    [SerializeField] private Text insBetDisplay;
    [SerializeField] private Button betButton;
    public Button DealBtn;
    public Button HitBtn;
    public Button StandBtn;

    // Start is called before the first frame update
    void Start()
    {
        moneyDisplay.text = "Current Money: " + data.getMoney();
        betDisplay.text = "Current Bet: 0";
        chipScript.updateChips(data.getMoney());
        betButton.interactable = true;
        HitBtn.interactable = false;
        StandBtn.interactable = false;
    }

    public void resetStuff()
    {
        HitBtn.interactable = false;
        StandBtn.interactable = false;
        currentMoney = data.getMoney();
        betAmount = 0;
        moneyDisplay.text = "Current Money: " + currentMoney;
        betDisplay.text = "Current Bet: " + betAmount;
        betButton.interactable = true;     
    }

        //Allows the player to make a bet and updates texts
    public void makeBet()
    {
        currentMoney = data.getMoney();
        if(betAmount > currentMoney)
        {
            Debug.Log("Too high of bet");
            return;
        }
        if(betAmount <= 0)
        {
            Debug.Log("Please bet more than 0");
            return;
        }
        currentMoney = currentMoney - betAmount;
        moneyDisplay.text = "Current Money: " + currentMoney;
        betDisplay.text = "Current Bet: " + betAmount;
        data.addMoney(-1 * betAmount);
        Debug.Log("Bet is " + betAmount);
        Debug.Log("Player money is " + currentMoney);
        betButton.interactable = false;
        DealBtn.interactable = true;
        slowBetAmount = betAmount;
        chipScript.updateChips(data.getMoney());
        data.resetCards();
        return;
    }

    public void doubleBet()
    {
        currentMoney = data.getMoney();
        if(currentMoney < betAmount)
        {
            Debug.Log("Too high of bet");
            return;
        }
        currentMoney = currentMoney - betAmount;
        data.addMoney(-1 * betAmount);
        moneyDisplay.text = "Current Money: " + currentMoney;
        betDisplay.text = "Current Bet: " + betAmount;
        slowBetAmount = betAmount;
        return;
    }

    public void insuranceBet()
    {
        currentMoney = data.getMoney();
        if(betAmount > currentMoney || betAmount > .5 * slowBetAmount)
        {
            Debug.Log("Too high of bet");
            return;
        }
        insBet = betAmount;
        currentMoney = currentMoney - betAmount;
        data.addMoney(-1 * betAmount);
        moneyDisplay.text = "Current Money: " + currentMoney;
        insBetDisplay.text = "Current Insurance Bet: " + insBet;
        return;
    }

    public void blackWinBet()
    {
        Debug.Log("21 was hit!");
        data.addMoney(2.5 * betAmount);
        resetStuff();
        return;
    }

    public void winBet()
    {
        Debug.Log("Bet won!");
        data.addMoney(2 * betAmount);
        resetStuff();
        return;
    }

    public void drawBet()
    {
        Debug.Log("Bet drawn!");
        data.addMoney(betAmount);
        resetStuff();
        return;
    }

    public void loseBet()
    {
        Debug.Log("Bet lost");
        data.addMoney(0);
        resetStuff();
        return;
    }

    //Reads in an input from the input field
    public void ReadStringInput(string s)
    {
        betAmount = double.Parse(s);
        Debug.Log("New betAmount is " + betAmount);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{

    public static double botNum;
    public GameObject bot1;
    public GameObject bot2;
    public GameObject bot3;
    public GameObject bot4;
    public GameObject bot5;

    private GameObject[] bots;

    // Start is called before the first frame update
    void Start()
    {
        bots = new GameObject[] { bot1, bot2, bot3, bot4, bot5 };

        SetActiveBots();
    }

    public void SetActiveBots()
    {
        for (int i = 0; i < bots.Length; i++)
        {
            bots[i].SetActive(i < botNum);
        }
    }
}

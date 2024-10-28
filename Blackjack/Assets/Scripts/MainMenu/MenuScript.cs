using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Dynamic;

public class MenuActiob : MonoBehaviour
{

    public Button open;
    public Button close;
    public GameObject scene;

    // Start is called before the first frame update
    void Start()
    {
        open.onClick.AddListener(openMethod);
        close.onClick.AddListener(closeMethod);
    }

    // Update is called once per frame
    public void openMethod()
    {
        scene.SetActive(true);
    }

    public void closeMethod()
    {
        scene.SetActive(false);
    }
}

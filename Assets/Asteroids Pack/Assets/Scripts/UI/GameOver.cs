using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private int continuePrice;
    public static GameOver instance;
    public GameObject dialog;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ShowDialog()
    {
        dialog.SetActive(true);
    }

    public void Restart()
    {
        Debug.Log("Restart");
    }

    public void Continue()
    {
        Debug.Log("Continue");
    }

    public void Home()
    {
        Debug.Log("Home");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    private int continuePrice;
    public static GameOver instance;
    public GameObject dialog;
    public GameObject notEnough;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        continuePrice = 20;
        instance = this;
    }

    public void ShowDialog()
    {
        dialog.SetActive(true);
        GameObject.FindGameObjectWithTag("ContinuePrice").GetComponent<TextMeshProUGUI>().SetText("Revive " + continuePrice);
    }

    public void CloseDialog()
    {
        notEnough.SetActive(false);
        dialog.SetActive(false);
    }

    public void Restart()
    {
        Debug.Log("Restart");
        notEnough.SetActive(false);
        dialog.SetActive(false);
        BG.instance.RestartBackGround();
        Score.SetAmount(0);
        Rocket.SetIsAlive(true);
        Rocket.instance.ResetPostion();
        continuePrice = 20;

    }
    private bool HasEnoughCoin()
    {
        return (Wallet.GetAmount() >= continuePrice);
        
    }

    private void ShowNotEnoughCoin()
    {
        notEnough.SetActive(true);
    }
    public void Continue()
    {
        if (HasEnoughCoin())
        {
            Wallet.SetAmount(Wallet.GetAmount() - continuePrice);
            Debug.Log("Continue");
            dialog.SetActive(false);
            Rocket.SetIsAlive(true);
            Rocket.instance.ResetPostion();
            continuePrice += continuePrice;
        }
        else
        {
            ShowNotEnoughCoin();
        }

    }

    public int GetContinuePrice()
    {
        return continuePrice;
    }

    public void Home()
    {
        Debug.Log("Home");
        dialog.SetActive(false);
        Score.SetAmount(0);
        Rocket.SetIsAlive(true);
        Rocket.instance.ResetPostion();
        continuePrice = 20;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

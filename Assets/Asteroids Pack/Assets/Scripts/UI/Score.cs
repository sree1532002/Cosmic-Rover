using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool continueGame;
    private static int amount;
    private static TextMeshProUGUI scoreText;

    void Start()
    {
        // If last game will not be continued.
        if (!continueGame)
        {
            // Reset score.
            amount = 0;
        }
        else
        {
            // Leave the last game score and disable continue game bool.
            continueGame = false;
        }

        // Display score.
        scoreText = this.GetComponent<TextMeshProUGUI>();
        DisplayAmount();
    }

    // Get score amount.
    public static int GetAmount()
    {
        return amount;
    }

    // Set score.
    public static void SetAmount(int amountToSet)
    {
        // Set new score.
        amount = amountToSet;
        // Display new score to the screen.
        DisplayAmount();

        // Check if new score is higher than highscore and if it's true than set new highscore.
        if (GetAmount() > HighScore.GetAmount())
        {
            HighScore.SetAmount(GetAmount());
        }
    }

    // Display score to the screen.
    private static void DisplayAmount()
    {
        scoreText.text = amount.ToString();
    }
}

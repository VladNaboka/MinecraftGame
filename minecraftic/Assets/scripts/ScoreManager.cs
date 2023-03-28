using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        // Update the UI Text object's text to show the current score value
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateScore(int value)
    {
        // Add the value to the score variable
        score = value;
    }
}
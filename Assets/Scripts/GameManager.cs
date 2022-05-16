using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int startingScore = 0;
    private int score;

    private void Start()
    {
        startingScore = score;
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}

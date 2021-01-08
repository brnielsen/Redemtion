using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Score score;
    public Text scoreText;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
        Score.updateScore += UpdateScoreText;
    }
    public void UpdateScoreText()
    {
        scoreText.text = score.currentScore.ToString();
    }
}

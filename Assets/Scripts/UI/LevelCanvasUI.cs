using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCanvasUI : MonoBehaviour
{
    GameManager gameManager;
    Countdown countdown;
    [SerializeField]
    GameObject levelEndDisplay;
    public Text levelEndScoreText;
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        score = gameManager.GetComponentInChildren<Score>();
        countdown = FindObjectOfType<Countdown>();
        levelEndDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.timeStart <= 0f)
        {
            gameManager.EndLevel();
            levelEndDisplay.SetActive(true);
            levelEndScoreText.text = score.finalScore.ToString();
        }
    }
}

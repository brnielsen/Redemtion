using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentScore;
    public int finalScore;

    private int potentialScore;

    public bool levelEnd = false;

    private void Awake()
    {
        potentialScore = FindObjectsOfType<SelectableObject>().Length;
        currentScore = 0;
        finalScore = 0;
    }

    private void Update()
    {
        if(levelEnd == true)
        {
            FinalScore();
        }
    }

    private int FinalScore()
    {
       finalScore = currentScore / potentialScore;
        return finalScore;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{

    public ReturnableType returnableTypeAccepted;

    private Score score;

    private void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SelectableObject selectableObject = other.GetComponent<SelectableObject>();
        if(selectableObject.returnableType == returnableTypeAccepted)
        {
            Debug.Log("Yay points!");
            score.currentScore += 1;
            //Play afirmative sound
        }
        else
        {
            Debug.Log("Don't put that in my mouth!");
            //Play negative sound

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour
{

    public float timeStart = 60f;
    public Text textBox;
    int minutes = 0;
    float seconds = 0;


    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeStart > 0f)
        {
            timeStart -= Time.deltaTime;

            if (timeStart >= 60f)
            {
                minutes = (int)timeStart / 60;
            }
            else
            {
                minutes = 0;
            }
            if (minutes > 0)
            {
                seconds = (int)timeStart - (minutes * 60f);
            }
            else
            {
                seconds = timeStart;
            }
        }
        else
        {
            timeStart = 0f;
        }


        textBox.text = minutes.ToString() + ":" +  Mathf.Round(seconds).ToString();


    }
}

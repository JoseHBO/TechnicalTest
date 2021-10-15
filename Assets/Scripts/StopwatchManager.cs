using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopwatchManager : MonoBehaviour
{
    float time = 30f;

    float seconds;

    public Text timeText;

    public static bool timeOver = false;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        seconds = Mathf.Floor(time % 30);

        if (seconds < 0)
        {
            timeOver = true;
        }
        else
        {
            ShowTime();
        }
    }

    private void ShowTime()
    {
        timeText.text = "Time: " + seconds.ToString();
    }
}

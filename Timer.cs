using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    private float time = 0;
    public Text help;

    // Update is called once per frame
    void LateUpdate()
    {
        time += Time.deltaTime;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timer.text = minutes.ToString() + ":" + seconds.ToString();

        if (minutes == 1 && FindObjectOfType<Checkpoint>().isCheckPointCompleted())
        {
            help.text = "Running (shift) could help you jupping";
        }

        else if (minutes == 3)
        {
            help.text = "Running (shift) could really help you";
        }

        else
        {
            help.text = "";
        }
    }
}

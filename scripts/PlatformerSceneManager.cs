using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformerSceneManager : MonoBehaviour
{
    public int collectibleCount = 0;
    public int collectibleGoal = 1;

    // UI
    public Text collectibleCounter;


    private void Start()
    {
        collectibleCounter.text = "0 / " + collectibleGoal.ToString();
    }


    public void Collect()
    {
        collectibleCount++;
        collectibleCounter.text = collectibleCount.ToString() + " / " +
            collectibleGoal.ToString();
        if (collectibleCount == collectibleGoal)
        {
            collectibleCounter.color = Color.green;
        }
    }

    public bool IsGameCompleted()
    {
        return (collectibleCount == collectibleGoal);
    }
}

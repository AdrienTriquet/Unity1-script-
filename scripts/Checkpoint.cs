using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public Transform respawnPoint;
    public Text checkPointText;
    private int timer = 7;
    private bool checkPointCompleted = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (checkPointCompleted){
                checkPointText.text = "Great ! You reached a checkpoint ! " +
                               "Keep going (or not) !";
                respawnPoint.position = transform.position;
                checkPointCompleted = false;
                StartCoroutine(Timer());
            }            
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        stopText();
    }

    void stopText()
    {
        checkPointText.text = "";
    }

    public bool isCheckPointCompleted()
    {
        return checkPointCompleted;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class declencheur_vertes : MonoBehaviour
{

    public Text deathText;
    public Transform respawnPoint;
    private int timer = 7;

    // To touch the bleu = enables the greens
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (FindObjectOfType<declencheur_bleu>().IsBlueCompleted() == false)
            {
                deathText.text = "Oops, now you know you have to touch the " +
                    "bleu platform before, shoud I have told you ?";

                other.gameObject.transform.position = respawnPoint.position;

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
        deathText.text = "";
    }
}

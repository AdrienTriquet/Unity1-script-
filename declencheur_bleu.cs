using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class declencheur_bleu : MonoBehaviour
{
    public bool collision;

    // Display victory text when player in endzone
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collision = true;
        }
    }

    public bool IsBlueCompleted()
    {
        return collision;
    }
}

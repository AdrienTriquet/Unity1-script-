using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndZone : MonoBehaviour
{
    // UI object to display victory text
    public Text victoryText;
    public object platform;
    private Animator anim;
    private bool arrivee = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Display victory text when player in endzone
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (FindObjectOfType<PlatformerSceneManager>().IsGameCompleted())
            {
                victoryText.text = "You are the best ! Was it too easy ?";
                victoryText.color = Color.blue;
                arrivee = true;

                //anim.SetBool("Victory", true);
                //anim.SetBool("isJumping", true);
            }
            else
            {
                Debug.Log("Collectibles missing");
                victoryText.text = "Too bad ! You miss a collectible ! " +
                    "You still have a solution : kill yourself !";

                FindObjectOfType<FallinPlatformTrap>().Replacement();
            }
        }
    }

    public bool isArrived()
    {
        return arrivee;
    }

    //void Update()
    //{
    //    if (FindObjectOfType<PlatformerSceneManager>().IsGameCompleted())
    //    {
    //        anim.SetBool("Victory", true);
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            victoryText.text = "";
        }
    }
}
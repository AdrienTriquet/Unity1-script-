using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class finish : MonoBehaviour
{

    //parameters of the script

    //the renderer used for changing materials

    private Renderer rend;
    // the materials we want to apply

    [SerializeField]
    private Material inMaterial;

    [SerializeField]
    private Material outMaterial;
    // Start is called before the first frame update
    void Start()
    {
        // get the renderer we want to change
        rend = GetComponent<Renderer>();
    }

    //change the material ontrigger enter
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter");
        rend.material = inMaterial;

    }

    //change the material on trigger exit
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exit");
        rend.material = outMaterial;
    }
}
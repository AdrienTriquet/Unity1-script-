using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions;

public class FallinPlatformTrap : MonoBehaviour
{

    public int timer1 = 1;
    public int timer2 = 10;
    private Rigidbody rb;
    public Transform respawnPointPlatform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(rb);
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(DelayFallTimer());
        }
    }

    IEnumerator DelayFallTimer()
    {
        yield return new WaitForSeconds(timer1);
        Fall();
    }

    void Fall()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    public void Replacement()
    {
        StartCoroutine(DelayRespawnTimer());
    }

    IEnumerator DelayRespawnTimer()
    {
        yield return new WaitForSeconds(timer2);
        transform.position = respawnPointPlatform.position;
        rb.isKinematic = true;
        rb.useGravity = false;
    }
}
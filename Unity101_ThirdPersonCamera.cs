﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity101_ThirdPersonCamera : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public Transform target, player;
    private float mouseX = 90;
    private float mouseY = 90;
    public float clampYUp, clampYDown;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.rotation = Quaternion.Euler(0, mouseY, 0);
    }

    private void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -1*clampYUp, clampYDown);

        transform.LookAt(target);
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}

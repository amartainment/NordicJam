using System;
using UnityEngine;

public class MouseCamLook : MonoBehaviour
{

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    public PlayerBehavior2D player2D;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    void Start()
    {
        player2D = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior2D>();
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        if (!player2D.playingGame)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            rotY += mouseX * mouseSensitivity * Time.deltaTime;
            rotX += mouseY * mouseSensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;



        }
    }


}
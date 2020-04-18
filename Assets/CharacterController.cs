
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    /* 
 * author : jiankaiwang
 * description : The script provides you with basic operations of first personal control.
 * platform : Unity
 * date : 2017/12
 */
    public PlayerBehavior2D player2D;
    public float speed = 10.0f;
    private float horizontalMovement;
    private float verticalMovement;
    Vector3 moveDirection;
    Rigidbody myBody;
    Vector3 startPosition;
    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        myBody = GetComponent<Rigidbody>();
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player2D.playingGame)
        {
            // Input.GetAxis() is used to get the user's input
            // You can furthor set it on Unity. (Edit, Project Settings, Input)
            horizontalMovement = Input.GetAxis("Horizontal");
            verticalMovement = Input.GetAxis("Vertical");
            moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
            if(Mathf.Abs(horizontalMovement) <0.1f && Mathf.Abs(verticalMovement) < 0.1f)
            {
                moveDirection = Vector3.zero;
            }
            

            //transform.Translate(transform.forward * horizontalMovement);

            if (Input.GetKeyDown("escape"))
            {
                // turn on the cursor
                Cursor.lockState = CursorLockMode.None;
            }
        }

        transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        //myBody.MovePosition(moveDirection * speed * Time.deltaTime);
        myBody.velocity = moveDirection * speed ;
    }
}
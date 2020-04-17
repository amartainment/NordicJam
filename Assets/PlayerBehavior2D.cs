using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior2D : MonoBehaviour
{
    public bool playingGame = false;
    public float playerSpeed;
    Rigidbody playerBody;
    
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playingGame)
        {
            checkForInput();
        }
    }

    void checkForInput()
    {
        Vector3 change = new Vector3(Input.GetAxis("Horizontal"),0,0);
        playerBody.MovePosition(transform.position + change * Time.deltaTime * playerSpeed);

    }
}

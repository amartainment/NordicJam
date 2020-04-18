using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior2D : MonoBehaviour
{
    
    public bool playingGame = false;
    public float playerSpeed;
    Rigidbody playerBody;
    private float moveInput;
    public  bool isGrounded = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask Whatis2DGround;
    public float jumpForce;
    private float jumpTimeCounter;
    public float JumpTime;
    public CharacterController2D controller;
    bool jump = false;
    bool isJumping = false;
    public GameObject tvGrey;
    AudioSource myAudioSource;
    public AudioClip jumpSound;
    ScreenManager screenDude;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.loop = false;
        myAudioSource.playOnAwake = false;
        playerBody = GetComponent<Rigidbody>();
        screenDude = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfPlayingGame();
        Death();
        if (playingGame)
        {
            moveInput = Input.GetAxisRaw("Horizontal") * playerSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                jumpTimeCounter = JumpTime;
                isJumping = true;
                myAudioSource.PlayOneShot(jumpSound);
            }

            if(Input.GetButton("Jump") &isJumping)
            {
                
                if(jumpTimeCounter >0)
                {
                    jump = true;
                    jumpTimeCounter -= Time.deltaTime;
                } else
                {
                    jump = false;
                    isJumping = false;
                }
            }

            if(Input.GetButtonUp("Jump"))
            {
                isJumping = false;
                jump = false;
            }
        }
    }

    public void Death()
    {
        if(transform.position.y < 5.5f)
        {
            screenDude.showLoseScreen();
            
           // SceneManager.LoadScene(1);
        }
    }
    private void FixedUpdate()
    {
        
            
            controller.Move(moveInput * Time.fixedDeltaTime, false, jump);
            
           
            /*
            moveInput = Input.GetAxisRaw("Horizontal");
            
            playerBody.velocity = new Vector3(moveInput * playerSpeed, playerBody.velocity.y, 0);
            

            if(isGrounded & Input.GetKeyDown(KeyCode.W))
            {
                playerBody.AddForce(Vector3.up * jumpForce);
            }

           */
    }
    

    public void checkForGround(bool grounded)
    {
        isGrounded = grounded;
    }
    void checkIfPlayingGame()
    {
        if(Input.GetKeyDown(KeyCode.E) )
        {
            if (!playingGame)
            {
                tvGrey.SetActive(false);
                playingGame = true;
            }
            else
            {
                tvGrey.SetActive(true);
                playingGame = false;
            }
        }
    }
    void checkForInput()
    {
        
        
    }
}

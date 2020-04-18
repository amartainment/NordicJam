using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public int thisScenesIndex;
    public int screenIndex = 0;
    PlayerBehavior2D myPlayer;
    public GameObject greyScreen;
    public Sprite launch;
    public Sprite winScreen;
    public Sprite loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.Find("Player").GetComponent<PlayerBehavior2D>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump") && GetComponent<SpriteRenderer>().enabled)
        {
            if (myPlayer.playingGame) { 
            GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                if(screenIndex==1)
                {
                    //winScene - increase 
                    if (thisScenesIndex == 0)
                    {
                        SceneManager.LoadScene(thisScenesIndex + 2);
                    } else
                    {
                        SceneManager.LoadScene(thisScenesIndex + 1);
                    }
                }

                if (screenIndex == 2)
                {
                    //lose screen - stay the same 
                    if (thisScenesIndex == 0)
                    {
                        SceneManager.LoadScene(thisScenesIndex + 1);
                    } else
                    {
                        SceneManager.LoadScene(thisScenesIndex);
                    }
                    
                }


            }

            

        }
        
    }

    public void showWinScreen()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<SpriteRenderer>().sprite = winScreen;
        screenIndex = 1;
    }

    public void showLoseScreen()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<SpriteRenderer>().sprite = loseScreen;
        screenIndex = 2;
    }
}

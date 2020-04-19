using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBehavior : MonoBehaviour
{
    ScreenManager screenDude;
    public AudioClip winSound;
    AudioSource mySource;
    // Start is called before the first frame update
    void Start()
    {
        screenDude = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            screenDude.showWinScreen();
            mySource.PlayOneShot(winSound);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBehavior : MonoBehaviour
{
    ScreenManager screenDude;
    // Start is called before the first frame update
    void Start()
    {
        screenDude = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
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
        }
    }
}

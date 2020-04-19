using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackRange;
    public int attackTime = 2;
    public Transform player2D;
    public bool playerInRange;
    Vector3 directionVector;
    public GameObject bulletPrefab;
    Coroutine fireShot;
    bool coroutRunning = false;
    AudioSource mySource;
    public AudioClip bullet;

    void Start()
    {
        player2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        checkIfPlayerInRange();
    }

    void checkIfPlayerInRange()
    {
        directionVector = player2D.position - transform.position;
        if (Vector3.SqrMagnitude(directionVector)<attackRange*attackRange)
        {
            playerInRange = true;
            if (!coroutRunning)
            {
                StartCoroutine(fireAShotIn(attackTime));
            }
        } else
        {
            playerInRange = false;
            StopCoroutine(fireAShotIn(attackTime));
        }
    }

    private IEnumerator fireAShotIn(int seconds)
    {
        coroutRunning = true;
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.GetComponent<BulletBehavior>().setTarget(player2D,transform.position);
        mySource.PlayOneShot(bullet);
        yield return new WaitForSeconds(seconds);
        
        coroutRunning = false;
    }
}

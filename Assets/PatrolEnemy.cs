using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    //Moving Block will have an array to store its checkpoints, it will move from one point to the other, till it reaches the end, then it moves backwards and vice versa
    // Start is called before the first frame update
    public Transform[] checkPoints;
    Vector3[] checkPointVectors;
    int index = 0;
    Vector3 targetPoint;
    Transform myPosition;
    public float speed;
    bool goingForward = true;
    public bool started = false;
    public float decisionTime = 2f;
 
   
    void Start()
    {
        
        checkPointVectors = new Vector3[checkPoints.Length];
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPointVectors[i] = checkPoints[i].position;
        }
        targetPoint = checkPointVectors[0];
        startEnemy();
    }

    public void startEnemy()
    {
        StartCoroutine(DoThisEvery(decisionTime));
    }
    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            moveToTarget();
        }
    }

   
    void moveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed);

    }

    void updateTarget(int a)
    {
        if (index == checkPointVectors.Length - 1)
        {
            goingForward = false;
        }

        if (goingForward && index < checkPointVectors.Length - 1)
        {
            index++;
            targetPoint = checkPointVectors[index];
        }

        if (!goingForward)
        {
            index--;
            targetPoint = checkPointVectors[index];
        }

        if (index == 0)
        {
            goingForward = true;
        }
    }

    private IEnumerator DoThisEvery(float seconds)
    {
        while (true)
        {
            updateTarget(1);
            yield return new WaitForSeconds(seconds);
            
        }
    }

}

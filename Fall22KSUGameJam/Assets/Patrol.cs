using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    #region Basic Patrol
    /*public float walkSpeed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] patrolPoints;
    private int randomPoint;

    private void Start()
    {
        waitTime = startWaitTime;
        randomPoint = Random.Range(0, patrolPoints.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[randomPoint].position, walkSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoints[randomPoint].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomPoint = Random.Range(0, patrolPoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
    }*/
    #endregion

    #region Advanced Patrol
    public float walkSpeed;
    private float waitTime;
    public float startWaitTime;

    public Transform patrolPoint;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        waitTime = startWaitTime;

        patrolPoint.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoint.position, walkSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoint.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                patrolPoint.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    #endregion
}

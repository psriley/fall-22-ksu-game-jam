using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float walkSpeed;
    public float waitTime;

    public Transform[] patrolPoints;
    private int randomPoint;

    private void Start()
    {
        randomPoint = Random.Range(0, patrolPoints.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[randomPoint].position, walkSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoints[randomPoint].position) < 0.2f)
        {
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        randomPoint = Random.Range(0, patrolPoints.Length);
    }
}

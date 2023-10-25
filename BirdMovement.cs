
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdMovement : MonoBehaviour
{
    public Transform[] waypoints;
    private Transform currentWaypoint;
    private int currentIndex;
    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        currentIndex = Random.Range(0, waypoints.Length);
        currentWaypoint = waypoints[currentIndex];
        transform.position = currentWaypoint.position;
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            currentIndex = UnityEngine.Random.Range(0, waypoints.Length);
            currentWaypoint = waypoints[currentIndex];
        }

        float step = 7f * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, step);

       
        if (transform.position.x < currentWaypoint.position.x)
        {
            spriteRenderer.flipX = false; 
        }
        else if (transform.position.x > currentWaypoint.position.x)
        {
            spriteRenderer.flipX = true; 
        }
    }
}
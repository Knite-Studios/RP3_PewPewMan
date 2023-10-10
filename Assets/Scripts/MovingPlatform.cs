using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentWayPoint = 0;
    [SerializeField] private float speed = 1f;


   //move the platform to the next waypoint
    void Update()
    {
        if (transform.position != wayPoints[currentWayPoint].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPoint].transform.position, speed * Time.deltaTime);
        }
        else
        {
            currentWayPoint = (currentWayPoint + 1) % wayPoints.Length;
        }
        
    }


    // This is to make the player move with the platform
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}

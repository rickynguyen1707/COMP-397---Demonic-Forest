using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject player;
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 1;




    private void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current = Random.Range(0, waypoints.Length);
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
    //private void OnTriggerEnter(Collider n)
    //{
    //    if (n.gameObject == player)
    //    {
    //        player.transform.parent = transform;
    //    }
    //}

    //private void OnTriggerExit(Collider n)
    //{
    //    if (n.gameObject == player)
    //    {
    //        player.transform.parent = null;
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        if(other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}

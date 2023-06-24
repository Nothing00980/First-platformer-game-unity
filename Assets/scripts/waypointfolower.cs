using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointfolower : MonoBehaviour
{
    // here the waypoints doesnt have components they are empty objects
    [SerializeField] private GameObject[] waypoints;

    private int currentwaypoint = 0;

    [SerializeField] private float speed = 2f;
   
 
    private void Update()
    {
        // distance between two vectors current mp and way points.
        if (Vector2.Distance(waypoints[currentwaypoint].transform.position,transform.position) < .1f)
        {
            currentwaypoint++;
            if(currentwaypoint >= waypoints.Length)
            {
                currentwaypoint = 0;
            }

        }
        //Debug.Log(Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentwaypoint].transform.position, Time.deltaTime * speed);


        
    }
}

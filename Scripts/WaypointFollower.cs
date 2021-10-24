using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currrentWayptIndex = 0;

    [SerializeField] private float platformSpeed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currrentWayptIndex].transform.position,
            transform.position)< 0.1f)
        {
            currrentWayptIndex++;
            if(currrentWayptIndex >= waypoints.Length)
            {
                currrentWayptIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(
            transform.position,
            waypoints[currrentWayptIndex].transform.position,
            Time.deltaTime * platformSpeed
            );
    }
}

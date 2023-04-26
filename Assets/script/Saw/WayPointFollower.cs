using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] WayPoints;
    [SerializeField] private float speed;
    private int WayPointIndex = 0;

    void Update()
    {
        if (Vector2.Distance(WayPoints[WayPointIndex].transform.position, transform.position) < .1f)
        {
            WayPointIndex++;
            if (WayPointIndex >= WayPoints.Length)
            {
                WayPointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, WayPoints[WayPointIndex].transform.position, Time.deltaTime * speed);
    }
}

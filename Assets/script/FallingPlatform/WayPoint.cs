using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] WayPoints;
    [SerializeField] private float speed;
    [SerializeField] private int range;

    private Animator anim;
    private Vector3 velocity = Vector3.zero;

    private float timer;
    private int WayPointIndex;
    private int delay;

    private void Start() {
        anim = GetComponent<Animator>();
        delay = Random.Range(0,range);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (Vector2.Distance(WayPoints[WayPointIndex].transform.position, transform.position) < .1f)
        {
            if (timer > delay)
            {
                WayPointIndex++;
                timer -= delay;
                anim.SetBool("fall", true);
            }
        }

        if (WayPointIndex >= WayPoints.Length)
        {
            WayPointIndex = 0;
            delay = Random.Range(0,range);
            anim.SetBool("fall", false);
        }
        transform.position = Vector3.SmoothDamp(transform.position, WayPoints[WayPointIndex].transform.position, ref velocity, speed);
    }
}

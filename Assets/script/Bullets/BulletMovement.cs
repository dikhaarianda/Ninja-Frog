using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float rangeShoot;
    [SerializeField] float speed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed * -1;
        Destroy(gameObject, rangeShoot);
    }
}

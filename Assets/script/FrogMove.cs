using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FrogMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool move;
    private float moveHorizontal;
    public float speed = 12;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = false;
    }

    public void PointerPlay()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveFrog();
    }

    private void MoveFrog() 
    {
        if (move)
        {
            moveHorizontal = speed;
            
        }
        else
        {
            moveHorizontal = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal, rb.velocity.y);
    }
}


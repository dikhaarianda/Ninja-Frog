using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerGetDamage : MonoBehaviour
{
    [SerializeField] private Text appleText;
    [SerializeField] private Text healthText;
    [SerializeField] private int health;

    private PlayerMovement move;
    private PlayerShoot playerShoot;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isTrap;
    private int apple;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        move = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    private void Update() {
        healthText.text = health.ToString();

        if (isTrap)
        {
            healthText.text = "0";
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("apple"))
        {
            Destroy(other.gameObject);
            apple++;
            appleText.text = apple.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Trap"))
        {
            anim.SetTrigger("death");
            StopMoving();
            isTrap = true;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            anim.SetTrigger("hit");
            StopMoving();
            isTrap = false;
        }
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void StopMoving()
    {
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0,0);
        move.enabled = false;
        playerShoot.enabled = false;
    }
}

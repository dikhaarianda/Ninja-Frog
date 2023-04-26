using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGetDamage : MonoBehaviour
{
    [SerializeField] private float DelayDestroy;
    public int health;
    [SerializeField] private Text healthText;
    private BossMovement attack;
    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
        attack = GetComponent<BossMovement>();
    }

    private void Update() {
        healthText.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            anim.SetTrigger("hit");
            attack.enabled = false;
            Invoke("destroy", DelayDestroy);
        }
    }

    private void destroy() {
        Destroy(gameObject);
    }
}
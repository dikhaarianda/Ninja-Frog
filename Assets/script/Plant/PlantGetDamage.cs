using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGetDamage : MonoBehaviour
{
    [SerializeField] private float DelayDestroy;
    [SerializeField] private int health;
    private PlantShoot shoot;
    private Animator anim;


    private void Start() {
        anim = GetComponent<Animator>();
        shoot = GetComponent<PlantShoot>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            anim.SetTrigger("hit");
            shoot.enabled = false;
            Invoke("destroy", DelayDestroy);
        }
    }

    private void destroy() {
        Destroy(gameObject);
    }
}

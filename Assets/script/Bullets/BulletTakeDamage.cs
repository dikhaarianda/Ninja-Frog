using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTakeDamage : MonoBehaviour
{
    [SerializeField] private int PlayerTakeDamage;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.transform.name == "Player")
        {
            other.GetComponent<PlayerGetDamage>().TakeDamage(PlayerTakeDamage);
            Destroy(gameObject);
        }
    }
}

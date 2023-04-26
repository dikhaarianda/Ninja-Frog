using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    [SerializeField] private int PlayerDamage;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.transform.name == "Player")
        {
            other.GetComponent<PlayerGetDamage>().TakeDamage(PlayerDamage);
        }
    }
}

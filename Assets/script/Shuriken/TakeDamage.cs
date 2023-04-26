using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] int BossTakeDamage;
    [SerializeField] private int PlantTakeDamage;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.transform.name == "Plant")
        {
            other.GetComponent<PlantGetDamage>().TakeDamage(PlantTakeDamage);
            Destroy(gameObject);
        }

        if (other.transform.name == "Boss")
        {
            other.GetComponent<BossGetDamage>().TakeDamage(BossTakeDamage);
            Destroy(gameObject);
        }
    }
}
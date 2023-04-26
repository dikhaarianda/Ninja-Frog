using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene3 : MonoBehaviour
{
    private BossGetDamage health;

    private void Start() {
        health = FindObjectOfType<BossGetDamage>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("wall") && health.health <= 0)
        {
            Destroy(collider.gameObject);
            SceneManager.LoadScene("FinalScene");
        }
    }
}

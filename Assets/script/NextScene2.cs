using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("wall"))
        {
            Destroy(collider.gameObject);

            SceneManager.LoadScene("BossScene");
        }
    }
}

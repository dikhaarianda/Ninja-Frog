using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collect_Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Trophy"))
        {
            Destroy(collider.gameObject);

            SceneManager.LoadScene("Scene1");
        }
    }
}

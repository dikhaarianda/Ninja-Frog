using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWithPlayer : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D other) {
        if (other.collider.name == "Player")
        {
            other.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.name == "Player")
        {
            other.collider.transform.SetParent(null);
        }
    }
}

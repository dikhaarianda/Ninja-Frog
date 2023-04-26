using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private AudioSource effectShuriken;
    [SerializeField] private Text shurikenText;

    private int shootCount = 3;
    private float lastShoot;

    private void Update()
    {
        shurikenText.text = shootCount.ToString();
        if (Input.GetKeyDown("m") && shootCount > 0)
        {
            Instantiate(bulletPrefabs, shootingPoint.position, transform.rotation);
            shootCount--;
            lastShoot = Time.time;
            effectShuriken.Play();
        }

        if (Time.time - lastShoot > 1f && shootCount <= 0)
        {
            shootCount = 3;
        }
    }

    private void shootEnable()
    {
        Instantiate(bulletPrefabs, shootingPoint.position, transform.rotation);
    }
}

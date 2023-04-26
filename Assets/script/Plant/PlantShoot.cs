using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantShoot : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private AudioSource effectPlant;
    [SerializeField] private float rangeShoot;
    [SerializeField] private float AttackDelay;

    private Animator anim;
    private float distance;
    private float timer;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        timer -= Time.deltaTime;

        if (distance < rangeShoot && player.transform.position.y > 1f)
        {
            if (timer <= 0)
            {
                Instantiate(bulletPrefabs, shootingPoint.position, Quaternion.identity);
                timer = 1/AttackDelay;
                anim.SetTrigger("attack");
                effectPlant.Play();
            }
        }
    }
}

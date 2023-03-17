using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float nextFireTime;
    public float fireRate = 0.2f;
    public GameObject player;
    float ammo;
    private AudioSource audioOutputSource;
    public AudioClip shootClip;
    public AudioClip outOfAmmoClip;

    void Start()
    {
        audioOutputSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // Debug.Log(player.GetComponent<PlayerController>().inventory.CanShoot());

        if (Input.GetMouseButtonDown(0) && nextFireTime < Time.time)
        {
            if (player.GetComponent<PlayerController>().inventory.CanShoot())
            {
                player.GetComponent<PlayerController>().inventory.Shoot(1);
                nextFireTime = Time.time + fireRate;
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
                audioOutputSource.PlayOneShot(shootClip);
            }
            else
            {
                audioOutputSource.PlayOneShot(outOfAmmoClip);
            }
        }
    }
}
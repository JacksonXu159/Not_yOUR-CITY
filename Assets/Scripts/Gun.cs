using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float nextFireTime;
    public GameObject player;
    float ammo;


    void Update()
    {
        ammo = player.GetComponent<PlayerController>().inventory.ammo;

        if((Input.GetMouseButtonDown(0) && nextFireTime < Time.time))
        {
            nextFireTime = Time.time + 1f;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
        }
    }
}

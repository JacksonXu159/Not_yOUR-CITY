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
        Debug.Log(player.GetComponent<PlayerController>().inventory.CanShoot());

        if(((Input.GetMouseButtonDown(0) && nextFireTime < Time.time)) && player.GetComponent<PlayerController>().inventory.CanShoot())
        {
            player.GetComponent<PlayerController>().inventory.Shoot(1);
            nextFireTime = Time.time + 1f;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
        }
    }
}

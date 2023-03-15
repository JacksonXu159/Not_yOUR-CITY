using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory
{

    public bool knife;
    public bool gun;
    public int ammo;

    // Start is called before the first frame update
    public Inventory()
    {
        this.knife = false;
        this.gun = false;
        this.ammo = 0;
    }

    public void PickupKnife()
    {
        knife = true;
    }
    public void PickupGun()
    {
        gun = true;
    }
    public void PickupAmmo(int amt)
    {
        ammo += amt;
    }

    public bool CanStab()
    {
        return knife;
    }

    public bool CanShoot()
    {
        return (gun && ammo > 0);
    }

    public bool hasKnife() {
        return this.knife;
    }

    public bool hasGun()
    {
        return (gun);
    }

    public bool hasAmmo()
    {
        return (ammo > 0);
    }

    public void Shoot(int amt)
    {
        if (CanShoot())
        {
            ammo -= amt;
        }
        else
        {
            Debug.LogError("Error occurred attempting to shoot.");
        }
    }

    public void Shoot()
    {
        Shoot(1);
    }
}

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

    public void add(string str) {
        if (str == "knife") 
            this.knife = true;
        if (str == "gun")
            this.gun = true;
        if (str == "arrow")
            this.ammo += 10;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory: MonoBehaviour
{

    public static bool sword;
    public static bool bow;
    public static int arrows;

    public TextMeshProUGUI inventoryDisplay;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory.sword = false;
        PlayerInventory.bow = false;
        PlayerInventory.arrows = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        inventoryDisplay.text = "Items : ";
        if (sword)
            inventoryDisplay.text += "Sword ";
        if (bow)
            inventoryDisplay.text += "Bow ";
        if (arrows > 0)
            inventoryDisplay.text += PlayerInventory.arrows.ToString() + " arrows";
    }

    public static void add(string str) {
        if (str == "sword") 
            PlayerInventory.sword = true;
        if (str == "bow")
            PlayerInventory.bow = true;
        if (str == "arrow")
            PlayerInventory.arrows += 10;
    }

}

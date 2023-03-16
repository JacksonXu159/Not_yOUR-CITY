using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryBar : MonoBehaviour
{
    public Image knifeBackgroundImage;
    public Image gunBackgroundImage;
    public TextMeshProUGUI ammoTMP;

    public Sprite hasNoneSprite;
    public Sprite hasPartialSprite;
    public Sprite hasFullSprite;


    public void Sync(Inventory inventory)
    {
        // Update knife
        knifeBackgroundImage.sprite = inventory.hasKnife() ? hasFullSprite : hasNoneSprite;

        // Update gun background
        if (inventory.hasGun() && inventory.hasAmmo())
        {
            gunBackgroundImage.sprite = hasFullSprite;
        }
        else if (!inventory.hasGun() && !inventory.hasAmmo())
        {
            gunBackgroundImage.sprite = hasNoneSprite;
        }
        else
        {
            gunBackgroundImage.sprite = hasPartialSprite;
        }

        // Update ammo count text
        ammoTMP.text = inventory.ammo.ToString();
    }
}

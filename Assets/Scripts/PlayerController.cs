using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField]public float moveSpeed = 1f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float maxHealth = 100;
    public float currentHealth;

    // Inventory UI
    public HealthBar healthBar;
    public Inventory inventory;
    public Transform inventoryUIKnife;
    public Transform inventoryUIGun;
    public Sprite hasNoneSprite;
    public Sprite hasPartialSprite;
    public Sprite hasFullSprite;

    // Inventory keybinds
    public KeyCode equipNothing; // Will this one day become "drop current item?"
    public KeyCode equipKnife; // Will this one day become "drop current item?"
    public KeyCode equipGun;
    public TextMeshProUGUI ControlsUI;

    int gunIndex = 0;

    public enum CurrentItem {
        NONE,
        GUN,
        KNIFE
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventory = new Inventory();
        if (inventoryUIGun == null) Debug.LogWarning("No UI specified for player's inventory");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        if(moveInput.x != 0 || moveInput.y != 0)
        {
            animator.SetBool("isMoving", true);
        } else {

            animator.SetBool("isMoving", false);
        }

        if(moveInput.x < 0) {
            spriteRenderer.flipX = true;
        } else if (moveInput.x > 0) {
            spriteRenderer.flipX = false;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Item") {
            if (other.gameObject.name == "knife")
                inventory.PickupKnife();
            if (other.gameObject.name == "gunDrop")
                inventory.PickupGun();
            if (other.gameObject.name == "ammo")
                inventory.PickupAmmo(30);
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        // Display keybinds/controls
        ControlsUI.text = "Controls: \n";
        ControlsUI.text += "None: "+ equipNothing + "\n";
        ControlsUI.text += "Knife: "+ equipKnife + "\n";
        ControlsUI.text += "Gun: "+ equipGun + "\n";


        // Keyevent handlers
        // Inventory keybinds
        if (Input.GetKeyDown(equipNothing))
        {
            inventory.Equip(Inventory.Equippable.NONE);
        }
        if (Input.GetKeyDown(equipKnife))
        {
            inventory.Equip(Inventory.Equippable.KNIFE);
        }
        if (Input.GetKeyDown(equipGun))
        {
            inventory.Equip(Inventory.Equippable.GUN);
        }
        
        // Update inventory UI
        // Update knife first
        Image knifeTextImg = inventoryUIKnife.GetComponentsInChildren<Image>()[0];
        knifeTextImg.sprite = inventory.hasKnife() ? hasFullSprite : hasNoneSprite;

        // Then update gun
        TextMeshProUGUI gunUIText = inventoryUIGun.GetComponentsInChildren<TextMeshProUGUI>()[0];
        Image gunUIImageBkgd = inventoryUIGun.GetComponentsInChildren<Image>()[0];
        gunUIText.text = inventory.ammo.ToString();
        if (inventory.hasGun() && inventory.hasAmmo())
        {
            gunUIImageBkgd.sprite = hasFullSprite;
        }
        else if (!inventory.hasGun() && !inventory.hasAmmo())
        {
            gunUIImageBkgd.sprite = hasNoneSprite;
        }
        else {
            gunUIImageBkgd.sprite = hasPartialSprite;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}

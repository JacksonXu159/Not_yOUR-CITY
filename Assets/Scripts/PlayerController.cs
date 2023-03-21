using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField] public float moveSpeed = 1f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    public float maxHealth = 100;
    public float currentHealth;
    public float enemyKills = 0;

    // Inventory UI
    public HealthBar healthBar;
    public Inventory inventory;
    public InventoryBar inventoryBar;

    // Inventory keybinds
    public KeyCode equipNothing; // Will this one day become "drop current item?"
    public KeyCode equipKnife; // Will this one day become "drop current item?"
    public KeyCode equipGun;
    public TextMeshProUGUI ControlsUI;

    // Sounds
    private AudioSource audioOutputSource;
    public AudioClip pickupKnifeClip;
    public AudioClip pickupGunClip;
    public AudioClip pickupAmmoClip;


    public enum CurrentItem
    {
        NONE,
        GUN,
        KNIFE
    }

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
        inventory = new Inventory();
        inventoryBar.Sync(inventory);

        audioOutputSource = gameObject.AddComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {

            animator.SetBool("isMoving", false);
        }

        if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            if (other.gameObject.name == "knife")
            {
                inventory.PickupKnife();
                audioOutputSource.PlayOneShot(pickupKnifeClip);
            }
            if (other.gameObject.name == "gunDrop")
            {
                inventory.PickupGun();
                audioOutputSource.PlayOneShot(pickupGunClip);
            }
            if (other.gameObject.name == "ammo")
            {
                inventory.PickupAmmo(30);
                audioOutputSource.PlayOneShot(pickupAmmoClip);
            }
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        // Display keybinds/controls
        ControlsUI.text = "Controls: \n";
        ControlsUI.text += "None: " + equipNothing + "\n";
        ControlsUI.text += "Knife: " + equipKnife + "\n";
        ControlsUI.text += "Gun: " + equipGun + "\n";


        // Keyevent handlers
        // Inventory keybinds
        if (Input.GetKeyDown(equipNothing))
        {
            inventory.Equip(Inventory.Equippable.NONE);
        }
        if (Input.GetKeyDown(equipKnife) && inventory.hasKnife())
        {
            inventory.Equip(Inventory.Equippable.KNIFE);
        }
        if (Input.GetKeyDown(equipGun) && inventory.hasGun())
        {
            inventory.Equip(Inventory.Equippable.GUN);
        }


        inventoryBar.Sync(inventory); // Expensive call but how else will a gun shooting update the inventory without iterating through a billion GameObjects?
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void healPlr(float amount)
    {
        currentHealth += amount;
        healthBar.SetHealth(currentHealth);
    }
}

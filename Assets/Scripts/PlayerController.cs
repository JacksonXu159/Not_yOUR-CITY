using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField]public float moveSpeed = 1f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Inventory inventory;
    public TextMeshProUGUI inventoryUI;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventory = new Inventory();
        if (inventoryUI == null) Debug.LogWarning("No UI specified for player's inventory");
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
            inventory.add(other.gameObject.name);
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        
        inventoryUI.text = "Items : ";
        if (inventory.knife)
            inventoryUI.text += "knife ";
        if (inventory.gun)
            inventoryUI.text += "gun ";
        if (inventory.ammo > 0)
            inventoryUI.text += inventory.ammo.ToString() + " ammo";
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }


}

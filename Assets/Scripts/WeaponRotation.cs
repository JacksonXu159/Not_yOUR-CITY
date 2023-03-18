using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }
    public SpriteRenderer characterRenderer;
    public SpriteRenderer weaponRenderer;
    private float yScale;
    public float yOffset;
    public float xOffset;
    public Transform plr;

    private int armLength = 1;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 scale = transform.localScale;
        yScale = scale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

        Vector2 scale = transform.localScale;

        // Place weapon a certain distance from current player, based on mousePosition's difference
        transform.position = new Vector3(
            plr.position.x + this.armLength * difference.x,
            plr.position.y + this.armLength * difference.y,
            plr.position.z + this.armLength * difference.z
        );

        if (Mathf.Abs(rotation_z) > 90)
        {
            scale.y = -yScale;
            characterRenderer.flipX = true;
            transform.position = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);
        }
        else if (Mathf.Abs(rotation_z) < 90)
        {
            scale.y = yScale;
            characterRenderer.flipX = false;
            transform.position = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);
        }
        transform.localScale = scale;
    }
}

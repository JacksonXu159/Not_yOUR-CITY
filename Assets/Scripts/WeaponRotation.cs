using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    public Vector2 PointerPosition {get; set;}
    public SpriteRenderer characterRenderer;
    public SpriteRenderer weaponRenderer;
    private float yScale;
    public float offset;
    public float xOffset;
    public float yOffset;
    public Transform plr;
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
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        Vector2 scale = transform.localScale;

        if(Mathf.Abs(rotation_z) > 90)
        {
            scale.y = -yScale;
            transform.position = new Vector3(plr.position.x - xOffset, plr.position.y+yOffset, plr.position.z);
        }else if(Mathf.Abs(rotation_z) < 90)
        {
            scale.y = yScale;
            transform.position = new Vector3(plr.position.x + xOffset, plr.position.y+yOffset, plr.position.z);

        }
        transform.localScale = scale;
    }
}

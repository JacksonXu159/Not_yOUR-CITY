using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    // Start is called before the first frame update
    void Start()
    {
    }

    void update(){

        if (Input.GetMouseButtonDown(0))
            bulletRB = GetComponent<Rigidbody2D>();
            Vector2 moveDir = (Input.mousePosition - transform.position).normalized * speed;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
            Destroy(this.gameObject, 2);

    }
}

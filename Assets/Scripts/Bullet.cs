// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Bullet : MonoBehaviour
// {
//     public GameObject target;
//     public float speed;
//     public Rigidbody2D bulletRB;
    // public Transform bulletSpawnPoint;
//     public GameObject bullet;
//     public float life;
//     public float delay = 3;
//     float timer;

//     // Start is called before the first frame update
 

//     void Update()
//     {

//         bullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
//         bulletRB = bullet.GetComponent<Rigidbody2D>();
        
//         target = GameObject.FindGameObjectWithTag("Player");

//         Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
//         bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
//         Destroy(bullet, life);
    


//         //StartCoroutine(WaitForFunction());
//     }
    
//     IEnumerator WaitForFunction()
//     {
//         yield return new WaitForSeconds(3);
//         Debug.Log("wait");

//     }
// }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Bullet : MonoBehaviour
// {
//     GameObject target;
//     public GameObject bullet;
//     public float speed;
//     Rigidbody2D bulletRB;
//     public Transform bulletSpawnPoint;
//     // Start is called before the first frame update
//     void Start()
//     {
//         //bulletRB = GetComponent<Rigidbody2D>();
//         bullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
//         bulletRB = bullet.GetComponent<Rigidbody2D>();
//         target = GameObject.FindGameObjectWithTag("Player");
//         Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
//         bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
//         Destroy(bullet, 2);
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Bullet : MonoBehaviour
{
    public float life = 3;
 
    void Awake()
    {
        Destroy(gameObject, life);
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
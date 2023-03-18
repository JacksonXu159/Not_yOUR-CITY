using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float nextFireTime;
    public float fireRate = 0.2f;
    public GameObject player;
    private AudioSource audioOutputSource;
    public AudioClip shootClip;
    Animator animator;
    private bool stabBool = true;

    void Start()
    {
        audioOutputSource = gameObject.AddComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // Debug.Log(player.GetComponent<PlayerController>().inventory.CanShoot());

        if (Input.GetMouseButtonDown(0) && nextFireTime < Time.time)
        {
            if ((player.GetComponent<PlayerController>().inventory.CanStab()) && stabBool)
            {
                StartCoroutine(slash());
                // Debug.Log("Stab");
                // animator.SetBool("Attack", true);
                // nextFireTime = Time.time + fireRate;
                // player.transform.Find("Sword").GetComponent<SwordDamage>().enabled=true;
                // audioOutputSource.PlayOneShot(shootClip);
            }
        }
    }


    private IEnumerator slash()
    {
        stabBool = false;
        animator.SetBool("Attack", true);
        nextFireTime = Time.time + fireRate;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 90f));
        player.transform.Find("Sword").GetComponent<SwordDamage>().enabled=true;
        audioOutputSource.PlayOneShot(shootClip);
        yield return new WaitForSeconds(0.3f);
        player.transform.Find("Sword").GetComponent<SwordDamage>().enabled=false;
        animator.SetBool("Attack", false);
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 0));
        stabBool = true;
    }
}

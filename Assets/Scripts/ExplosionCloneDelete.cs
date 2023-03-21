using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCloneDelete : MonoBehaviour
{
    public int life = 1;
    private AudioSource audioOutputSource;
    public AudioClip missileExplodeClip;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);

    }

    void Start()
    {
        audioOutputSource.volume  = 0.4f;
        audioOutputSource = gameObject.AddComponent<AudioSource>();
        audioOutputSource.PlayOneShot(missileExplodeClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

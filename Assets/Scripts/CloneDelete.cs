using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDelete : MonoBehaviour
{
    public int life = 1;

    void Awake(){
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

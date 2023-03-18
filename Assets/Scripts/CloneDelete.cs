using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDelete : MonoBehaviour
{
    public int life = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAmogus : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf){
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 180f);
            
        }
        
    }
}

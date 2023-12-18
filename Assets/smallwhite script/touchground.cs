using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchground : MonoBehaviour
{
    // Start is called before the first frame update
    public bool grounded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "viking")
        {
            grounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "viking")
        {
            grounded = false;
        }
    }
}

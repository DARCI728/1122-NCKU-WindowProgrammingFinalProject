using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public GameObject player;
    Vector3 vv;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(d), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.name != "p")
        {
            
        vv = player.transform.position;
        vv.y += 1;
        transform.position = vv;
        }
        
    }
    private void d()
    {
        if (transform.name != "p")
        {
        Destroy(gameObject);
        }
    }
}

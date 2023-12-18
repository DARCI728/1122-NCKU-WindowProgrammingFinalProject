using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class chestopen : MonoBehaviour
{
    public GameObject chestroof;
    public GameObject coinspawner;

    public bool opened;
    public float degree;
    // Start is called before the first frame update
    void Start()
    {
        degree = 0;
        opened = false;
        chestroof.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (opened && degree >-90)
        {
            degree-=(float)0.5;
            chestroof.transform.localRotation = Quaternion.Euler(degree, 0f, 0f);
            
        }
        if (degree == -90)
        {
            if (transform.GetComponent<Interactable>().Name=="chest")
            {
                degree = -91;
                coinspawner.GetComponent<coinspawner>().summon(transform.position);
                Destroy(gameObject);
            }
        }
        
    }
    public void openchest()
    {
        opened = true;
    }
}

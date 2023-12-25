using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffchest : MonoBehaviour
{
    public Animator animator;
    public GameObject buff1;
    public GameObject buff2;
    public GameObject buff3;
    public GameObject buff4;
    float duration = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("havopened"))
        {
            animator.SetBool("havopened", false);
            Invoke(nameof(finish), duration);
            
        }
    }
    private void finish()
    {
        int buff = Random.Range(0, 4);
            if (buff == 0)
            {
                buff1.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
            else if (buff==1)
            {
                buff2.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
            else if (buff == 2)
            {
                buff3.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
            else
            {
                buff4.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
    }
}

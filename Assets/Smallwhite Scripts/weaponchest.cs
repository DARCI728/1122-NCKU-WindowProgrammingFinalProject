using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponchest : MonoBehaviour
{
    float duration = 1.5f;
    public Animator animator;
    public GameObject weapon1;
    public GameObject weapon2;
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
        int weapon = Random.Range(0, 2);
            if (weapon == 0)
            {
                weapon1.transform.position=new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
            }
            else
            {
                weapon2.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
    }
}

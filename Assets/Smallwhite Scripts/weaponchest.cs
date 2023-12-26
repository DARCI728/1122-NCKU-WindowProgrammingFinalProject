using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponchest : MonoBehaviour
{
    float duration = 1.5f;
    public Animator animator;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
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
        int weapon = Random.Range(0, 4);
        //Instantiate(weapon1, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Quaternion(0, 0, 0, 0));
        if (weapon == 0)
        {
            Instantiate(weapon1, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Quaternion(0, 0, 0, 0));
        }
        else if(weapon==1)
        {
            Instantiate(weapon2, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Quaternion(0, 0, 0, 0));
        }
        else if (weapon == 2)
        {
            Instantiate(weapon3, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Quaternion(0, 0, 0, 0));
        }
        else
        {
            Instantiate(weapon4, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Quaternion(0, 0, 0, 0));
        }
    }
}

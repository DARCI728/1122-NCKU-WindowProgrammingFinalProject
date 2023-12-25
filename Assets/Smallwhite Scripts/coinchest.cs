using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinchest : MonoBehaviour
{
    public Animator animator;
    public GameObject coinui;
    float duration=1.5f;
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
        coinui.GetComponent<coinui>().money += 10;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinchest : MonoBehaviour {
    public Animator animator;
    public GameObject coinui;
    public int coin = 60;
    float duration = 1.5f;

    void Update() {
        if (animator.GetBool("havopened")) {
            animator.SetBool("havopened", false);
            Invoke(nameof(finish), duration);
        }
    }

    private void finish() {
        coinui.GetComponent<coinui>().money += coin;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinchest : MonoBehaviour {
    public Animator animator;
    public int coin;
    float duration = 1.5f;
    
    GameObject coinui;

    void Update() {
        if (animator.GetBool("havopened")) {
            animator.SetBool("havopened", false);
            Invoke(nameof(finish), duration);
        }

        coinui = GameObject.Find("UI/Screen Space Canvas/money");
    }

    private void finish() {
        coinui.GetComponent<coinui>().money += coin;
    }
}

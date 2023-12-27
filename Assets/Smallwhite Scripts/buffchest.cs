using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffchest : MonoBehaviour {
    public Animator animator;
    public GameObject buff1;
    public GameObject buff2;
    public GameObject buff3;
    public GameObject buff4;
    float duration = 1f;

    void Start() {

    }

    void Update() {
        if (animator.GetBool("havopened")) {
            animator.SetBool("havopened", false);
            Invoke(nameof(finish), duration);
        }
    }

    private void finish() {
        int buff = Random.Range(0, 4);

        if (buff == 0) {
            Instantiate(buff1, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Quaternion(0, 0, 0, 0));
        } else if (buff == 1) {
            Instantiate(buff2, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Quaternion(0, 0, 0, 0));
        } else if (buff == 2) {
            Instantiate(buff3, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Quaternion(0, 0, 0, 0));
        } else {
            Instantiate(buff4, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Quaternion(0, 0, 0, 0));
        }
    }
}

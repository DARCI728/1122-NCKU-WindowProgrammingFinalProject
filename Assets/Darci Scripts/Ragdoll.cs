using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour {
    [SerializeField] float vanashTime = 0;

    void Start() {

    }

    void Update() {
        vanashTime -= Time.deltaTime;

        if (vanashTime < 0) {
            Destroy(this.gameObject);
        }
    }
}

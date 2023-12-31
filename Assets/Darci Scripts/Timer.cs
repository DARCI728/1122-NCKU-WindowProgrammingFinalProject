using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    public float time = 0;
    GameObject pointer;

    void Start() {
        time = 0;
        pointer = GameObject.Find("UI/Screen Space Canvas/Pointer"); ;
    }

    void Update() {
        time += Time.deltaTime;

        Vector3 vector3 = pointer.transform.position;
        if (vector3.x < 1880) {
            vector3.x += (100f/180f) * Time.deltaTime;
            pointer.transform.position = vector3;
        }
    }
}

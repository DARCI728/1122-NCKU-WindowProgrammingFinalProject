using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFace : MonoBehaviour {
    GameObject player;
    Transform cameraTransform;

    void Start() {
        player = GameObject.Find("Player");
        cameraTransform = Camera.main.transform;
    }

    void Update() {
        transform.LookAt(2 * transform.position - cameraTransform.position);
    }
}

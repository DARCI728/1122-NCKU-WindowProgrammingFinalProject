using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinui : MonoBehaviour {
    public int money = 0;

    private void Start() {
        GetComponent<Text>().text = "0";
    }

    private void Update() {
        GetComponent<Text>().text = money.ToString();
    }
}

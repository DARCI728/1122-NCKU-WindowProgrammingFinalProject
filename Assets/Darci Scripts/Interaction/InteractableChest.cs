using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableChest : Interactable {
    private GameObject canves;
    private droneai droneai;
    private BuffDrone buffDrone;
    private Animator animator;
    private BoxCollider boxCollider;

    [Header("Locked Chest Options")]
    public string chestID;
    public int need_coins;
    public bool isOpen;
    private int coins;

    public override void Start() {
        base.Start();
        canves = GameObject.Find("UI/Screen Space Canvas/money");
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        isOpen = false;

        if (this.tag == "Robot") {
            droneai = this.GetComponent<droneai>();
        }

        if (this.tag == "BuffDrone") {
            buffDrone = this.GetComponent<BuffDrone>();
        }

        RandomRotate();
    }

    public void Update() {
        coins = canves.GetComponent<coinui>().money;
    }

    protected override void Interaction() {
        base.Interaction();
        coins = canves.GetComponent<coinui>().money;

        if (this.tag == "Robot") {
            if (coins >= need_coins) {
                droneai.triggered = true;
                boxCollider.enabled = false;
                canves.GetComponent<coinui>().money -= need_coins;
                return;
            }
        }

        if (this.tag == "BuffDrone") {
            if (coins >= need_coins) {
                buffDrone.triggered = true;
                boxCollider.enabled = false;
                canves.GetComponent<coinui>().money -= need_coins;
                return;
            }
        }

        if (coins >= need_coins) {
            if (!isOpen) {
                OpenChest();
                boxCollider.enabled = false;
                canves.GetComponent<coinui>().money -= need_coins;
            }
        }
    }

    void OpenChest() {
        animator.SetTrigger("OpenChest");
        isOpen = !isOpen;
    }

    void RandomRotate() {
        float randomYRotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, randomYRotation, 0f);
    }
}

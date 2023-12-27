using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableChest : Interactable {
    private GameObject canves;
    private droneai droneai;
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
}

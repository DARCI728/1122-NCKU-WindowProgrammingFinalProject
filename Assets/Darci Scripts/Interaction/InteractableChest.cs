using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableChest : Interactable {
    private Animator animator;
    [Header("Locked Chest Options")]
    public bool isLocked;
    public string chestID;
    public bool isOpen;

    public override void Start() {
        base.Start();
        animator = GetComponent<Animator>();
        isOpen = false;
    }

    protected override void Interaction() {
        base.Interaction();

        if (!isLocked) {
            if (!isOpen) {
                OpenChest();
                print("Opening the chest");

            } 
        } 
    }

    void OpenChest() {
        animator.SetTrigger("OpenChest");
        isOpen = !isOpen;
    }
}

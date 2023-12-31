using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePortal : Interactable {
    [Header("Item Data")]
    [SerializeField] string itemName;

    GameObject player;

    public override void Start() {
        base.Start();
        interactableName = itemName;
        player = GameObject.Find("Player");
    }

    protected override void Interaction() {
        base.Interaction();

    }
}

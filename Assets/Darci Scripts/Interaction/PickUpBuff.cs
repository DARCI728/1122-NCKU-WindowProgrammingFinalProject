using System.Collections;
using UnityEngine;

public class PickUpBuff : Interactable {
    [Header("Item Data")]
    [SerializeField] string itemName;

    public override void Start() {
        base.Start();
        interactableName = itemName;
    }

    protected override void Interaction() {
        base.Interaction();
    }
}

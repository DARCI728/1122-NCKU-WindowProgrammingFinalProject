using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractablePortal : Interactable {
    [Header("Item Data")]
    [SerializeField] string itemName;
    [SerializeField] int destinationScene;

    public override void Start() {
        base.Start();
        interactableName = itemName;
    }

    protected override void Interaction() {
        base.Interaction();
        SceneManager.LoadSceneAsync(destinationScene);
    }
}

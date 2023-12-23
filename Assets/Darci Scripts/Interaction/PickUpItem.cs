using System.Collections;
using UnityEngine;

public class PickUpItem : Interactable {
    [Header("Item Data")]
    [SerializeField] string itemName;
    [SerializeField] GameObject weapon;

    GameObject player;
    EquipmentSystem equipmentSystem;

    public override void Start() {
        base.Start();
        interactableName = itemName;
        player = GameObject.Find("Player");
        equipmentSystem = player.GetComponent<EquipmentSystem>();
    }

    protected override void Interaction() {
        base.Interaction();

        if (equipmentSystem.currentWeaponInSheath != null) {
            equipmentSystem.weapon = weapon;

            if (weapon.tag == "GreatSword") {
                equipmentSystem.weaponSheath = player.transform.Find("mixamorig:Hips/GreatSwordSheathHolder").gameObject;
            } else if (weapon.tag == "Sword") {
                equipmentSystem.weaponSheath = player.transform.Find("mixamorig:Hips/SwordSheathHolder").gameObject;
            }

            Destroy(equipmentSystem.currentWeaponInSheath);
            equipmentSystem.currentWeaponInSheath = Instantiate(weapon, equipmentSystem.weaponSheath.transform);
            
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour {
    public GameObject weapon;
    public GameObject weaponHolder;
    public GameObject weaponSheath;
    public GameObject currentWeaponInHand;
    public GameObject currentWeaponInSheath;

    void Start() {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
    }

    private void Update() {

    }

    public void DrawWeapon() {
        currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
        Destroy(currentWeaponInSheath);
    }

    public void SheathWeapon() {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        Destroy(currentWeaponInHand);
    }

    public void StartDealDamage() {
        currentWeaponInHand.GetComponentInChildren<DamageDealer>().StartDealDamage();
    }
    public void EndDealDamage() {
        currentWeaponInHand.GetComponentInChildren<DamageDealer>().EndDealDamage();
    }
}

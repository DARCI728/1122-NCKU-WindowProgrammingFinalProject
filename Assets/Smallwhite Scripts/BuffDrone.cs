using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffDrone : MonoBehaviour {
    Vector3 v;
    public GameObject particle;
    public int speed = 6;
    public int followdis = 6;
    public float per = 5;
    public float wait = 5;
    public bool triggered = false;

    bool adding = false;

    GameObject player;
    GameObject weapon;
    DamageDealer damagedealer;

    void Start() {
        player = GameObject.Find("Player");
    }

    void Update() {
        if (player != null) {
            weapon = player.GetComponent<EquipmentSystem>().currentWeaponInHand;
        }

        if (weapon != null) {
            damagedealer = weapon.GetComponentInChildren<DamageDealer>();
        }

        if (triggered && player != null) {
            float px = player.transform.position.x;
            float pz = player.transform.position.z;
            float dx = transform.position.x;
            float dz = transform.position.z;
            if ((px - dx) * (px - dx) + (pz - dz) * (pz - dz) > followdis * followdis) {
                v = player.transform.position;
                v.y += 3;
                transform.position = Vector3.MoveTowards(transform.position, v, speed * Time.deltaTime);

            } else if (transform.position.y != player.transform.position.y) {
                v = transform.position;
                v.y = player.transform.position.y + 3;
                transform.position = Vector3.MoveTowards(transform.position, v, speed * Time.deltaTime);

            }
            if ((px - dx) * (px - dx) + (pz - dz) * (pz - dz) <= followdis * followdis) {
                if (adding == false && damagedealer != null) {
                    Invoke(nameof(buff), wait);
                    adding = true;
                }
            }
        }
    }

    private void buff() {
        Vector3 playerPosition = player.transform.position;
        GameObject particleInstance = Instantiate(particle, playerPosition, Quaternion.identity);
        particleInstance.transform.parent = player.transform;
        damagedealer.weaponDamage += 5;
        Destroy(particleInstance, 5f);
        Invoke(nameof(cancel), per);
    }

    private void cancel() {
        adding = false;
        damagedealer.weaponDamage -= 5;
    }
}

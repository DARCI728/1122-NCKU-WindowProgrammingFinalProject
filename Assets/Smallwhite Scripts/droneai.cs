using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneai : MonoBehaviour {
    Vector3 v;
    public GameObject particle;
    public int speed = 3;
    public int followdis = 3;
    public float per = 3;
    public float addhp = 3;
    public bool triggered = true;

    float maxhealth;
    bool adding = false;

    GameObject player;
    HealthSystem healthSystem;

    void Start() {
        player = GameObject.Find("Player");
        healthSystem = player.GetComponent<HealthSystem>();
    }

    void Update() {
        maxhealth = healthSystem.max_health;

        if (triggered) {
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
                if (player.GetComponent<HealthSystem>().health < maxhealth) {
                    if (adding == false) {
                        Invoke(nameof(add), per);
                        adding = true;
                    }

                }
            }
        }
    }

    private void add() {
        if (player.GetComponent<HealthSystem>().health < maxhealth) {
            Vector3 playerPosition = player.transform.position;
            GameObject particleInstance = Instantiate(particle, playerPosition, Quaternion.identity);
            particleInstance.transform.parent = player.transform;
            Destroy(particleInstance, 5f);
            player.GetComponent<HealthSystem>().health += addhp;
            if (player.GetComponent<HealthSystem>().health > maxhealth) {
                player.GetComponent<HealthSystem>().health = maxhealth;
            }

        }
        adding = false;
    }
}

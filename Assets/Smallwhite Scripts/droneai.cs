using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class droneai : MonoBehaviour {
    Vector3 v;
    public GameObject particle;
    public int speed = 6;
    public int followdis = 6;
    public float per = 5;
    public float addhp = 5;
    public bool triggered = true;

    bool adding = false;

    GameObject player;
    GameObject healt_bar_green;
    HealthSystem healthSystem;

    void Start() {
        player = GameObject.Find("Player");
        healthSystem = player.GetComponent<HealthSystem>();
        healt_bar_green = GameObject.Find("UI/Screen Space Canvas/Health Bar Green");
    }

    void Update() {
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
                if (healthSystem.health < healthSystem.max_health) {
                    if (adding == false) {
                        Invoke(nameof(add), per);
                        adding = true;
                    }
                }
            }
        }
    }

    private void add() {
        if (healthSystem.health < healthSystem.max_health) {
            Vector3 playerPosition = player.transform.position;
            GameObject particleInstance = Instantiate(particle, playerPosition, Quaternion.identity);
            particleInstance.transform.parent = player.transform;
            Destroy(particleInstance, 5f);
            healthSystem.health += addhp;
            if (healthSystem.health > healthSystem.max_health) {
                healthSystem.health = healthSystem.max_health;
            }

            float hp_percent = healthSystem.health / healthSystem.max_health;
            healt_bar_green.GetComponent<Image>().fillAmount = hp_percent;
        }
        adding = false;
    }
}

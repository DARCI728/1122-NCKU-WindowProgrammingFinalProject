using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

    public enum CollectibleTypes { NoType, HP, Defense, Speed, JumpHeight, Type5 };
    public CollectibleTypes CollectibleType;
    public bool rotate;
    public float rotationSpeed;
    public AudioClip collectSound;
    public GameObject collectEffect;
    
    GameObject player;
    GameObject healt_bar_red;
    GameObject healt_bar_green;

    Character character;
    HealthSystem healthSystem;

    void Start() {
        player = GameObject.Find("Player");
        character = player.GetComponent<Character>();
        healthSystem = character.GetComponent<HealthSystem>();
        healt_bar_red = GameObject.Find("UI/Screen Space Canvas/Health Bar Red");
        healt_bar_green = GameObject.Find("UI/Screen Space Canvas/Health Bar Green");
    }

    void Update() {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Collect();
        }
    }

    public void Collect() {
        if (collectSound)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);


        if (CollectibleType == CollectibleTypes.NoType) {
            Debug.Log("Do NoType Command");
        }

        if (CollectibleType == CollectibleTypes.HP) {
            if (healthSystem.max_health < 200) {
                healthSystem.max_health += 20;
            }

            Vector3 currrent_position = healt_bar_red.transform.position;
            Vector3 currrent_scale = healt_bar_red.transform.localScale;
            currrent_position.x += 30;
            currrent_scale.x += 0.1f;
            healt_bar_green.transform.position = currrent_position;
            healt_bar_green.transform.localScale = currrent_scale;
            healt_bar_red.transform.position = currrent_position;
            healt_bar_red.transform.localScale = currrent_scale;

            float hp_percent = healthSystem.health / healthSystem.max_health;
            healt_bar_green.GetComponent<Image>().fillAmount = hp_percent;
        }

        if (CollectibleType == CollectibleTypes.Defense) {
            if (healthSystem.defense < 10) {
                healthSystem.defense += 2;
            }
        }

        if (CollectibleType == CollectibleTypes.Speed) {
            if (character.playerSpeed < 10f) {
                character.playerSpeed += 1f;
                character.crouchSpeed += 1f;
                character.sprintSpeed += 1f;
            }
        }

        if (CollectibleType == CollectibleTypes.JumpHeight) {
            character.jumpHeight += 0.2f;
        }
        if (CollectibleType == CollectibleTypes.Type5) {
            if (character.jumpHeight < 2f) {
                character.jumpHeight += 0.2f;
            }
        }

        Destroy(gameObject);
    }
}

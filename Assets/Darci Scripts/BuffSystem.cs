using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSystem : MonoBehaviour {
    [SerializeField] GameObject max_health_buff;
    [SerializeField] GameObject defense_buff;
    [SerializeField] GameObject speed_buff;
    [SerializeField] GameObject jump_height_buff;

    HealthSystem health_system;
    Character character;

    void Start() {
        health_system = GetComponent<HealthSystem>();
        character = GetComponent<Character>();
    }

    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        GameObject otherObject = collision.gameObject;
        string otherObjectName = otherObject.name;

        if (otherObject == max_health_buff) {
            if (health_system.max_health < 200) {
                health_system.max_health += 5;
                Debug.Log("HP++");
            }
        }

        if (otherObjectName == defense_buff.name) {
            health_system.defense += 2;
        }

        if (otherObjectName == speed_buff.name) {
            character.playerSpeed += 1f;
            character.crouchSpeed += 1f;
            character.sprintSpeed += 1f;
        }

        if (otherObjectName == max_health_buff.name) {
            character.jumpHeight += 0.2f;
        }
    }
}

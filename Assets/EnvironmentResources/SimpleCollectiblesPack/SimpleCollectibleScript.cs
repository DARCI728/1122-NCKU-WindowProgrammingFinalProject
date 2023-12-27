using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

    public enum CollectibleTypes { NoType, HP, Defense, Speed, JumpHeight, Type5 }; // you can replace this with your own labels for the types of collectibles in your game!

    public CollectibleTypes CollectibleType; // this gameObject's type

    public bool rotate; // do you want it to rotate?

    public float rotationSpeed;

    public AudioClip collectSound;

    public GameObject collectEffect;

    GameObject player;
    Character character;
    HealthSystem healthSystem;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
        character = player.GetComponent<Character>();
        healthSystem = character.GetComponent<HealthSystem>();
    }

    // Update is called once per frame
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

        //Below is space to add in your code for what happens based on the collectible type

        if (CollectibleType == CollectibleTypes.NoType) {

            //Add in code here;

            Debug.Log("Do NoType Command");
        }
        if (CollectibleType == CollectibleTypes.HP) {
            healthSystem.max_health += 10;

            Debug.Log("Do NoType Command");
        }
        if (CollectibleType == CollectibleTypes.Defense) {
            healthSystem.defense += 2;
            
            Debug.Log("Do NoType Command");
        }
        if (CollectibleType == CollectibleTypes.Speed) {
            character.playerSpeed += 1f;
            character.crouchSpeed += 1f;
            character.sprintSpeed += 1f;

            Debug.Log("Do NoType Command");
        }
        if (CollectibleType == CollectibleTypes.JumpHeight) {
            character.jumpHeight += 0.2f;

            Debug.Log("Do NoType Command");
        }
        if (CollectibleType == CollectibleTypes.Type5) {

            //Add in code here;

            Debug.Log("Do NoType Command");
        }

        gameObject.SetActive(false);
        //Destroy (gameObject);
    }
}

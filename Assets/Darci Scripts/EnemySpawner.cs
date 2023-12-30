using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;
    public int enemyMax = 10;
    public int enemyMaxSpawnOneTime = 2;
    public float intervalTime = 5;
    public float random_spawn = 15;
    public float spawn_distance = 20;
    float distance;

    GameObject player;
    int enemyCount;
    float timer;

    void Start() {
        timer = intervalTime;
        player = GameObject.Find("Player");
    }

    void Update() {
        if (player != null) {
            distance = Vector3.Distance(transform.position, player.transform.position);
        }

        if (distance < spawn_distance) {
            if (enemyCount >= enemyMax) {
                return;
            }

            timer -= Time.deltaTime;

            if (timer <= 0) {
                timer = intervalTime;

                int enemySpawnNum = Random.Range(1, enemyMaxSpawnOneTime);

                for (int i = 0; i < enemySpawnNum; i++) {
                    Vector3 vector3 = transform.position;
                    vector3.x = transform.position.x + Random.Range(-random_spawn, random_spawn);
                    vector3.y = transform.position.y + Random.Range(0, 2);
                    vector3.z = transform.position.z + Random.Range(-random_spawn, random_spawn);

                    Instantiate(enemy, vector3, Quaternion.identity);
                    enemyCount++;
                }

                Transform vfx = this.transform.Find("Magic circle 2");

                if (vfx != null) {
                    Destroy(vfx.gameObject, 1f);
                }
            }
        }
    }
}

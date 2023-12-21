using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject player;
    public GameObject enemy;
    public int enemyMax;
    private int enemyCount;
    public int enemyMaxSpawnOneTime;
    public float intervalTime;
    private float timer;
    public float distance;

    void Start() {
        timer = intervalTime;
    }

    void Update() {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 20) {
            if (enemyCount >= enemyMax) {
                return;
            }

            timer -= Time.deltaTime;

            if (timer <= 0) {
                timer = intervalTime;

                int enemySpawnNum = Random.Range(1, enemyMaxSpawnOneTime);

                for (int i = 0; i < enemySpawnNum; i++) {
                    Vector3 vector3 = transform.position;
                    vector3.x = transform.position.x + Random.Range(-15, 15);
                    vector3.y = transform.position.y + Random.Range(0, 2);
                    vector3.z = transform.position.z + Random.Range(-15, 15);

                    Instantiate(enemy, vector3, Quaternion.identity);
                    enemyCount++;
                }
            }
        }
    }
}

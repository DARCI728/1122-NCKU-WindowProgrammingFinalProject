using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class droneai2 : MonoBehaviour
{
    Vector3 v;
    public int speed = 6;
    public int followdis = 6;
    public float per = 2;
    public float wait = 3;
    public bool triggered = true;

    bool adding = false;

    GameObject player;
    DamageDealer damagedealer;

    void Start()
    {
        player = GameObject.Find("Player");
        damagedealer = player.GetComponent<EquipmentSystem>().weapon.gameObject.GetComponentInChildren<DamageDealer>();
    }

    void Update()
    {
        if (triggered)
        {
            float px = player.transform.position.x;
            float pz = player.transform.position.z;
            float dx = transform.position.x;
            float dz = transform.position.z;
            if ((px - dx) * (px - dx) + (pz - dz) * (pz - dz) > followdis * followdis)
            {
                v = player.transform.position;
                v.y += 3;
                transform.position = Vector3.MoveTowards(transform.position, v, speed * Time.deltaTime);

            }
            else if (transform.position.y != player.transform.position.y)
            {
                v = transform.position;
                v.y = player.transform.position.y + 3;
                transform.position = Vector3.MoveTowards(transform.position, v, speed * Time.deltaTime);

            }
            if ((px - dx) * (px - dx) + (pz - dz) * (pz - dz) <= followdis * followdis)
            { 
                if (adding == false)
                {
                    Invoke(nameof(buff), wait);
                    adding = true;
                }
            }
        }
    }

    private void buff()
    {
        damagedealer.weaponDamage += 5;
        Invoke(nameof(cancel), per);
    }
    private void cancel()
    {
        adding = false;
        damagedealer.weaponDamage -= 5;

    }
}

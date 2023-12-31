using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    [SerializeField] float health = 10;
    [SerializeField] int dropCoin = 2;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject ragdoll;
    [SerializeField] GameObject portal;

    [Header("Combat")]
    [SerializeField] float attackCD = 3f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float aggroRange = 4f;

    GameObject player;
    GameObject Timer;
    coinui coin;
    Transform canvas;

    NavMeshAgent agent;
    Animator animator;

    float timePassed;
    float newDestinationCD = 0.5f;
    float time;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        time = GameObject.Find("Timer").GetComponent<Timer>().time;
        coin = GameObject.Find("UI/Screen Space Canvas/money").GetComponent<coinui>();
        canvas = this.transform.Find("Canvas");

        float multiplier = (int)(time / 180) * 0.2f + 1f;
        health *= multiplier;

        EnemyDamageDealer[] damageDealers = GetComponentsInChildren<EnemyDamageDealer>();

        foreach (EnemyDamageDealer damageDealer in damageDealers) {
            damageDealer.weaponDamage *= multiplier;
        }
    }

    void Update() {
        animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);

        if (player == null) {
            return;
        }

        if (timePassed >= attackCD) {
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange) {
                animator.SetInteger("attack_num", Random.Range(0, 4));
                animator.SetTrigger("attack");
                timePassed = 0;
            }
        }
        timePassed += Time.deltaTime;

        if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange) {
            newDestinationCD = 0.5f;
            agent.SetDestination(player.transform.position);
        }
        newDestinationCD -= Time.deltaTime;
        transform.LookAt(player.transform);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            print(true);
            player = collision.gameObject;
        }
    }

    void Die() {
        Instantiate(ragdoll, transform.position, transform.rotation);

        if (this.tag == "Boss") {
            Vector3 vector3 = transform.position;
            vector3.x += 5;
            vector3.y += 3;
            Instantiate(portal, vector3, transform.rotation);
        }

        Destroy(this.gameObject);
        coin.money += dropCoin;
    }

    public void TakeDamage(float damageAmount) {
        health -= damageAmount;
        animator.SetTrigger("damage");
        PopUpHurtValue(damageAmount);
        CameraShake.Instance.ShakeCamera(2f, 0.2f);

        if (health <= 0) {
            Die();
        }
    }
    public void StartDealDamage() {
        EnemyDamageDealer[] damageDealers = GetComponentsInChildren<EnemyDamageDealer>();

        foreach (EnemyDamageDealer damageDealer in damageDealers) {
            damageDealer.StartDealDamage();
        }
    }
    public void EndDealDamage() {
        EnemyDamageDealer[] damageDealers = GetComponentsInChildren<EnemyDamageDealer>();

        foreach (EnemyDamageDealer damageDealer in damageDealers) {
            damageDealer.EndDealDamage();
        }
    }

    public void HitVFX(Vector3 hitPosition) {
        GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        Destroy(hit, 2f);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

    void PopUpHurtValue(float value) {
        canvas = this.transform.Find("Canvas");
        GameObject hurtValue = Instantiate(Resources.Load<GameObject>("Damage Number"), canvas);
        hurtValue.GetComponent<TextMeshProUGUI>().text = value.ToString();
        hurtValue.transform.localPosition = new Vector3(Random.Range(-2f, 2f), Random.Range(0, 1f), 0);
        Destroy(hurtValue, 10f);
    }
}

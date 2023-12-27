using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {
    public float health = 100;
    public float max_health = 100;
    public float defense = 0;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject ragdoll;

    Animator animator;
    void Start() {
        animator = GetComponent<Animator>();
        health = max_health;
    }

    public void TakeDamage(float damageAmount) {
        health -= (damageAmount - defense);
        animator.SetTrigger("damage");
        CameraShake.Instance.ShakeCamera(10f, 0.5f);

        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        Instantiate(ragdoll, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    public void HitVFX(Vector3 hitPosition) {
        GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        Destroy(hit, 3f);
    }
}

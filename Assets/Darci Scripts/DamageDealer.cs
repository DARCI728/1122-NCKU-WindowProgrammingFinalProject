using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class DamageDealer : MonoBehaviour {
    bool canDealDamage;
    List<GameObject> hasDealtDamage;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    [SerializeField] GameObject hitVFX;

    void Start() {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
    }

    void Update() {
        if (canDealDamage) {
            RaycastHit hit;

            int layerMask = 1 << 9;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask)) {
                if (hit.transform.TryGetComponent(out Enemy enemy) && !hasDealtDamage.Contains(hit.transform.gameObject)) {
                    HitVFX(hit.point);
                    enemy.TakeDamage(weaponDamage);
                    enemy.HitVFX(hit.point);
                    CameraShake.Instance.ShakeCamera(5f, 0.5f);
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
            }
        }
    }
    public void StartDealDamage() {
        canDealDamage = true;
        hasDealtDamage.Clear();
    }

    public void EndDealDamage() {
        canDealDamage = false;
    }

    public void HitVFX(Vector3 hitPosition) {
        Quaternion rotation = Quaternion.Euler(0f, 135f, 0f);
        GameObject hit = Instantiate(hitVFX, hitPosition, rotation);
        Destroy(hit, 1f);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}

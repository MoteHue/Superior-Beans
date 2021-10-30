using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisstolAttack : Ability
{

    Camera cam;
    public int damageAmount = 20;
    public GameObject projectile;
    public GameObject deathEffect;

    override public void Start() {
        base.Start();
        cam = FindObjectOfType<Camera>();
    }

    public override void DoAbility() {
        RaycastHit hit;
        bool hitObject = Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity);
        if (hitObject) {
            if (hit.collider != null) {
                if (hit.collider.gameObject.CompareTag("Enemy")) {
                    hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(damageAmount);
                    Die();
                }
            }
        }
        Instantiate(projectile, transform.position, cam.transform.rotation);
    }

    void Die() {
        Instantiate(deathEffect, transform.position, cam.transform.rotation);
        Destroy(gameObject);
    }

}

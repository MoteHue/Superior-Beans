using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Ability {
    Camera cam;
    public Color rayColour;
    public int damageAmount = 40;
    public GameObject deathEffect;

    public override void Start() {
        base.Start();
        cam = FindObjectOfType<Camera>();
    }

    public override void DoAbility() {
        RaycastHit hit;
        bool hitObject = Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity);
        if (hitObject) {
            //Debug.DrawLine(transform.position, hit.point, rayColour, 0.5f, true);
            Instantiate(deathEffect, hit.point, transform.rotation);
        } else {
            //Debug.DrawLine(transform.position, cam.transform.position + cam.transform.forward * 10f, rayColour, 0.5f, true);
        }

        if (hit.collider != null) {
            if (hit.collider.gameObject.TryGetComponent(out Enemy hitEnemy)) {
                hitEnemy.TakeDamage(damageAmount);
            }
        }



    }

}

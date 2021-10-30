using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAbility : Ability
{
    Camera cam;
    public Color rayColour;
    public int damageAmount = 40;

    private void Start() {
        cam = FindObjectOfType<Camera>();
    }

    public override void doAbility() {
        RaycastHit hit;
        bool hitObject = Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity);
        if (hitObject) {
            Debug.DrawLine(transform.position, hit.point, rayColour, 0.5f, true);
        } else {
            Debug.DrawLine(transform.position, cam.transform.position + cam.transform.forward * 10f , rayColour, 0.5f, true);
        }

        if (hit.collider != null) {
            if (hit.collider.gameObject.TryGetComponent(out Enemy hitEnemy)) {
                hitEnemy.TakeDamage(damageAmount);
            }
        }
        
        
        
    }

}

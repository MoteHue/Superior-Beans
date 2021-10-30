using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFGAttack : Ability
{

    Camera cam;
    public GameObject projectile;

    private void Start() {
        cam = FindObjectOfType<Camera>();
    }

    public override void DoAbility() {
        Instantiate(projectile, transform.position, cam.transform.rotation);
    }

}

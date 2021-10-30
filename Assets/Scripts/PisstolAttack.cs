using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisstolAttack : Ability
{

    Camera cam;
    public GameObject projectile;

    override public void Start() {
        base.Start();
        cam = FindObjectOfType<Camera>();
    }

    public override void DoAbility() {
        Instantiate(projectile, transform.position, cam.transform.rotation);
    }

}

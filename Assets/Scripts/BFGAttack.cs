using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFGAttack : Ability
{

    public GameObject projectile;

    public override void DoAbility() {
        Instantiate(projectile, transform.position, transform.rotation);
    }

}

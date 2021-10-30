using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAttack : Ability
{

    public int numberOfFireballs = 10;
    public float timeBetweenBalls = 0.5f;
    public GameObject fireball;

    public override void DoAbility() {
        StartCoroutine(LaunchFireballs(timeBetweenBalls));
    }

    IEnumerator LaunchFireballs(float timeBetweenBalls) {
        for (int i = 0; i < numberOfFireballs; i++) {
            Instantiate(fireball, transform.position, transform.rotation);
            yield return new WaitForSecondsRealtime(timeBetweenBalls);
        }
    }
}

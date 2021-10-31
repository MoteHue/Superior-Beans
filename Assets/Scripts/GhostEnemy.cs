using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : Enemy
{
    public override void DoBehaviour() {
        base.DoBehaviour();
        GoToPlayer(0.1f);
        if (Vector3.Distance(player.position, transform.position) < .5f) AttackPlayer(attackDamage);
        transform.LookAt(player);
    }

    void GoToPlayer(float s) {
        Vector3 direction = new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z).normalized;
        if ((new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z).magnitude > 1f)) {
            rb.MovePosition(transform.position - s * direction);
        }
        //if ((xyDistance < 1f) && (player.position.y > transform.position.y)) Jump();
    }
}

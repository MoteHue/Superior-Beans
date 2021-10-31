using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarBehaviour : MonoBehaviour
{
    public Enemy enemy;

    private void Start() {
        if (enemy == null) enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3((float) enemy.health / (float) enemy.maxHealth * 0.07f, transform.localScale.y, 1);
    }
}

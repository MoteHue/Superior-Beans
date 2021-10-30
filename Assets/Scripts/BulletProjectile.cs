using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {
    public float moveSpeed = 0.5f;
    public int damageAmount = 10;
    Rigidbody rb;

    private void Start() {
        rb = FindObjectOfType<Rigidbody>();
        //rb.AddForce(transform.forward * moveSpeed);
        Invoke(nameof(Die), 3f);
    }

    void Die() {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}

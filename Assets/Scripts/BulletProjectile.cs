using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {
    public float moveSpeed = 0.5f;
    public int damageAmount = 10;
    Rigidbody rb;
    public GameObject deathEffect;

    private void Start() {
        rb = FindObjectOfType<Rigidbody>();
        //rb.AddForce(transform.forward * moveSpeed);
        Invoke(nameof(Die), 3f);
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        bool hitObject = Physics.Raycast(transform.position, transform.forward, out hit, 10f);
        Debug.DrawLine(transform.position, transform.position + transform.forward * 10f, Color.blue, 0.5f, true);
        if (hitObject) {
            
            if (hit.collider != null) {
                if (hit.collider.gameObject.CompareTag("Enemy")) {
                    hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(damageAmount);
                    Die();
                }
            }
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    void Die() {
        if (deathEffect != null) Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

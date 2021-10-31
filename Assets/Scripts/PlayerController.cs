using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int maxJumps = 2;
    public float moveSpeed = 6f;
    public float jumpForce = 5f;
    public float lookSensitivity = 2f;

    public int health;
    public int maxHealth = 100;

    Camera cam;
    Rigidbody rb;
    int remainingJumps;
    UICanvasBehaviour UICanvas;

    public bool isSlowed = false;
    

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        UICanvas = FindObjectOfType<UICanvasBehaviour>();

        Physics.gravity *= 2f;

        Cursor.lockState = CursorLockMode.Locked;
        remainingJumps = maxJumps;

        health = maxHealth;

        UICanvas.SetHealth(health);
    }

    // Update is called once per frame
    void Update() {
        // Movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        Vector3 vel = rb.velocity;
        if (direction.magnitude >= 0.1f) {
            // rb.AddForce(Vector3.forward, ForceMode.VelocityChange);
            vel.x = 0;
            vel.z = 0;
            vel += transform.right * moveHorizontal * moveSpeed;
            vel += transform.forward * moveVertical * moveSpeed;
            // rb.MovePosition(transform.position + (transform.forward * moveVertical + transform.right * moveHorizontal) * moveSpeed * Time.deltaTime);
            rb.velocity = vel;
        }
        if (Input.GetKeyDown(KeyCode.Space) && remainingJumps > 0) {
            vel.y = 0f;
            rb.velocity = vel;
            rb.AddForce(Vector3.up * jumpForce);
            remainingJumps--;
        }

        // Camera
        float lookHorizontal = Input.GetAxisRaw("Mouse X");
        float lookVertical = Input.GetAxisRaw("Mouse Y");
        transform.Rotate(transform.up * lookHorizontal * lookSensitivity);
        cam.transform.RotateAround(transform.position, transform.right, -lookVertical * lookSensitivity);
    }

    private void FixedUpdate() {
        
    }

    private void OnCollisionEnter(Collision collision) {
        remainingJumps = maxJumps;
    }

    public void TakeDamage(int amount) {
        health = Mathf.Max(health - amount, 0);
        UICanvas.SetHealth(health);
        if (health == 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("lmao you died");
        SceneManager.LoadScene("GameOver");
    }

}

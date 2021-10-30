using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float duration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Die), duration);
    }

    void Die() {
        Destroy(gameObject);
    }
}

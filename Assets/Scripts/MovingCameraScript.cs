using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCameraScript : MonoBehaviour
{

    public float moveSpeed = 3f;
    public bool move;

    public Vector3 startpos;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = startpos;
    }

    public void Reset() {
        transform.localPosition = startpos;
    }

    // Update is called once per frame
    void Update()
    {
        if (move) transform.localPosition += direction * moveSpeed * Time.deltaTime;
    }
}

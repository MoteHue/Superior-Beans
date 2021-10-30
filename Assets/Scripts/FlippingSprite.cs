using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippingSprite : MonoBehaviour
{

    bool canFlip = true;
    public SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        //playerController = FindObjectOfType<PlayerController>();
        spriteR = FindObjectOfType<SpriteRenderer>();
        canFlip = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canFlip){
            canFlip = false;
            // Flip
            spriteR.flipX = !spriteR.flipX;
            StartCoroutine(DeactivateAfterTime(1f));
        }
    }

    IEnumerator DeactivateAfterTime(float time) {
        yield return new WaitForSecondsRealtime(time);
        canFlip = true;
    }
}

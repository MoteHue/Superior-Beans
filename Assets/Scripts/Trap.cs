using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 6) && (!playerController.isSlowed))
        {
            Debug.Log("gggggggggggggggggg");
            //playerController = other.GetComponent<PlayerController>();
            playerController.moveSpeed *= 0.5f;
            Debug.Log(playerController.moveSpeed);
            playerController.isSlowed = true;
            StartCoroutine(DeactivateAfterTime(30f));
        }
        /*if (other.CompareTag("Player"))
        {
            Debug.Log("ghfyhfyhf");
            //playerController = other.GetComponent<PlayerController>();
            playerController.moveSpeed *= 0.5f;
            StartCoroutine(DeactivateAfterTime(30f));
        }*/
    }

    IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        playerController.moveSpeed *= 2f;
        playerController.isSlowed = false;
    }
}

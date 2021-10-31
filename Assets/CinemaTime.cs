using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaTime : MonoBehaviour
{
    public List<Camera> cameras;
    public List<MovingCameraScript> movs;

    public void ChangeCamera(int index) {
        foreach (Camera cam in cameras) {
            cam.enabled = false;
        }
        cameras[index].enabled = true;
        if (cameras[index].gameObject.GetComponent<MovingCameraScript>() != null) {
            cameras[index].gameObject.GetComponent<MovingCameraScript>().Reset();
            cameras[index].gameObject.GetComponent<MovingCameraScript>().move = true;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            ChangeCamera(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            ChangeCamera(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            ChangeCamera(2);
            movs[0].Reset();
            movs[0].move = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            ChangeCamera(3);
            movs[1].Reset();
            movs[1].move = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            ChangeCamera(4);
        }
    }
}

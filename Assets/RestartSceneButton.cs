using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartSceneButton : MonoBehaviour
{
    private void Start() {
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartScene() {
        SceneManager.LoadScene(0);
    }
}

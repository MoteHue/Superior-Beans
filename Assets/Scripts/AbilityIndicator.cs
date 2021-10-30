using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AbilityIndicator : MonoBehaviour
{

    public Text reloadText;
    public float timeToReload;
    public Image image;

    private void Update() {
        if (reloadText.IsActive()) {
            timeToReload -= Time.deltaTime;
            reloadText.text = Math.Round(timeToReload, 1).ToString();
        }
    }
}

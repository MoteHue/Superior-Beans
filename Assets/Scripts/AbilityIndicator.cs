using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIndicator : MonoBehaviour
{

    public Text reloadText;
    public float timeToReload;
    public Image image;

    private void Update() {
        if (reloadText.IsActive()) {
            timeToReload -= Time.deltaTime;
            reloadText.text = Mathf.CeilToInt(timeToReload).ToString();
        }
    }
}

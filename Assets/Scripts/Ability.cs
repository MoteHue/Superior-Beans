using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    public int reloadTime;
    bool canActivate = true;
    public AbilityIndicator abilityIndicator;
    public KeyCode activationKeyCode;

    virtual public void Start() {
        abilityIndicator.keyText.text = activationKeyCode.ToString();
    }

    private void Update() {
        if (Input.GetKeyDown(activationKeyCode)) {
            Activate();
        }
    }

    virtual public void DoAbility() {
        // Overridden by abilities
    }

    public void Activate() {
        if (canActivate) {
            canActivate = false;
            DoAbility();
            StartCoroutine(DeactivateAfterTime(reloadTime));
        }
    }

    IEnumerator DeactivateAfterTime(float time) {
        abilityIndicator.timeToReload = time;
        abilityIndicator.reloadText.gameObject.SetActive(true);
        Color defaultImageColour = abilityIndicator.image.color;
        abilityIndicator.image.color = new Color32(100, 100, 100, 255);
        yield return new WaitForSecondsRealtime(time);
        abilityIndicator.reloadText.gameObject.SetActive(false);
        abilityIndicator.image.color = defaultImageColour;
        canActivate = true;
    }
}

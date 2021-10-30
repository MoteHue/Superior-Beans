using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    public float reloadTime;
    public Sprite UISprite;
    public Sprite weaponSprite;
    public Vector3 weaponScale;
    public bool canActivate = true;
    public AbilityIndicator abilityIndicator;
    public KeyCode activationKeyCode;
    public string weaponName; 

    virtual public void Start() {
        UpdateIndicator();
    }

    public void UpdateIndicator() {
        abilityIndicator.keyText.text = activationKeyCode.ToString();
        abilityIndicator.image.sprite = UISprite;
        abilityIndicator.weaponName.text = weaponName;
    }

    private void Update() {
        if (Input.GetKey(activationKeyCode) & canActivate) {
            Activate();
        }
    }

    virtual public void DoAbility() {
        // Overridden by abilities
    }

    public void Activate() {
        canActivate = false;
        DoAbility();
        StartCoroutine(DeactivateAfterTime(reloadTime));
    }

    IEnumerator DeactivateAfterTime(float time) {
        abilityIndicator.timeToReload = time;
        abilityIndicator.reloadText.gameObject.SetActive(true);
        abilityIndicator.image.color = new Color32(100, 100, 100, 255);
        yield return new WaitForSecondsRealtime(time);
        abilityIndicator.reloadText.gameObject.SetActive(false);
        abilityIndicator.image.color = Color.white;
        canActivate = true;
    }
}

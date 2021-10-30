using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> abilities;
    int activeAbility = 0;
    public SpriteRenderer weaponImage;

    private void Start() {
        ChangeWeapon(0);
        for (int i = 1; i < abilities.Count; i++) {
            abilities[i].enabled = false;
        }
    }

    public void ChangeWeapon(int index) {
        abilities[activeAbility].enabled = false;
        activeAbility = index;
        abilities[index].enabled = true;
        abilities[index].UpdateIndicator();
        weaponImage.sprite = abilities[index].weaponSprite;
        weaponImage.transform.localScale = abilities[index].weaponScale;
        abilities[index].abilityIndicator.reloadText.gameObject.SetActive(false);
        abilities[index].abilityIndicator.timeToReload = 0;
        abilities[index].canActivate = true;
        abilities[index].abilityIndicator.image.color = Color.white;
    }

    private void Update() {
        
    }
}

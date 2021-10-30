using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> abilities;
    int activeAbility = 0;
    public SpriteRenderer weaponImage;

    public void ChangeWeapon(int index) {
        abilities[activeAbility].enabled = false;
        activeAbility = index;
        abilities[index].enabled = true;
        abilities[index].UpdateIndicator();
        weaponImage.sprite = abilities[index].weaponSprite;
        weaponImage.transform.localScale = abilities[index].weaponScale;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            ChangeWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { 
            ChangeWeapon(1);
        }
    }
}

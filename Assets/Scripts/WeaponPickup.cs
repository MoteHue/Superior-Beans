using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : MonoBehaviour
{
    AbilityManager abilityManager;
    public int weaponIndex;
    SpriteRenderer spriteRenderer;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            abilityManager.ChangeWeapon(weaponIndex);
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        abilityManager = FindObjectOfType<AbilityManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = abilityManager.abilities[weaponIndex].weaponSprite;
        transform.localScale = abilityManager.abilities[weaponIndex].weaponScale;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 2f, 0f));
    }
}

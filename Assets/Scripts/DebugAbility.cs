using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAbility : Ability
{
    public override void doAbility() {
        Debug.Log("Ability Activated");
    }
}

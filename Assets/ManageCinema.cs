using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageCinema : MonoBehaviour
{
    Text uitext;
    public CinemaTime ct;

    private void Start() {
        StartCoroutine(nameof(doCinema));
    }

    IEnumerator doCinema() {
        ct.ChangeCamera(0);
        yield return new WaitForSecondsRealtime(3);
        ct.ChangeCamera(1);
        yield return new WaitForSecondsRealtime(3);
        ct.ChangeCamera(2);
        yield return new WaitForSecondsRealtime(6);
        ct.ChangeCamera(3);
        yield return new WaitForSecondsRealtime(6);
        ct.ChangeCamera(4);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageCinema : MonoBehaviour
{
    public Text uitext;
    public CinemaTime ct;
    public GameObject JedLyingDown;
    public GameObject JedWibbly;

    private void Start() {

        StartCoroutine(nameof(doCinema));
        
    }

    IEnumerator doCinema() {
        ct.ChangeCamera(0);
        JedLyingDown.SetActive(true);
        JedWibbly.SetActive(false);
        StartCoroutine(fillInText("The Tower..."));
        yield return new WaitForSecondsRealtime(3);
        ct.ChangeCamera(1);
        StartCoroutine(fillInText("Hair falls down..."));
        yield return new WaitForSecondsRealtime(3);
        ct.ChangeCamera(2);
        StartCoroutine(fillInText("And we all know what hair means..."));
        yield return new WaitForSecondsRealtime(6);
        ct.ChangeCamera(3);
        StartCoroutine(fillInText("A princess!"));
        yield return new WaitForSecondsRealtime(6);
        JedLyingDown.SetActive(false);
        JedWibbly.SetActive(true);
        StartCoroutine(fillInText("Hold on a minute..."));
        ct.ChangeCamera(4);
    }

    IEnumerator fillInText(string text) {
        uitext.text = ""; 
        int counter = 0;
        while (counter < text.Length) {
            yield return new WaitForSecondsRealtime(0.1f);
            uitext.text += text[counter];
            counter++;
        }
    }
}

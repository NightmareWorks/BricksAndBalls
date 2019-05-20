using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink_Effect : MonoBehaviour
{
    public static bool visible;
     private void Start() {
        visible = true;
        StartCoroutine(BlinkCo());
     }
    IEnumerator BlinkCo() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        while (visible) {
            yield return new WaitForSeconds(1.0f);
            Color c = sr.color;
            float saveAlpha = c.a;
            c.a = 0.8f;
            sr.color = c;

            yield return new WaitForSeconds(0.2f);
            c.a = 0.5f;
            sr.color = c;

            yield return new WaitForSeconds(0.2f);
            c.a = 0.8f;
            sr.color = c;

            yield return new WaitForSeconds(0.2f);

            c.a = saveAlpha;
            sr.color = c;
        }
    }
}

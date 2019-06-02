using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink_Effect : MonoBehaviour
{
    public static bool visible= false;
    private int cont=0;
    private SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    internal void Blink()
    {
        gameObject.SetActive(true);
        visible = true;
    }
    internal void Init()
    {
        visible = false;
        gameObject.SetActive(false);
    }
    private void Update()
    {

        if (visible) {
            cont++;
            Color c = sr.color;
            float saveAlpha = c.a;
            if (cont % 40 == 0)
            {
                c.a = 0.8f;
                sr.color = c;
            }
            else if (cont % 90 == 0)
            {
                c.a = 0.5f;
                sr.color = c;
            }
            c.a = saveAlpha;
            sr.color = c;

        }

    }
}

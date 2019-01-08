using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarsUI : MonoBehaviour
{
    public Image[] stars = new Image[3];
    public Text textPuntuacion;
    [SerializeField]
    public Sprite[] activateStar = new Sprite[2];
    private Slider slider_;

    private int[] puntosEstrella= new int[2];

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        slider_ = GetComponent<Slider>();

        stars[0].sprite = activateStar[1];
        stars[1].sprite = activateStar[0];
        stars[2].sprite = activateStar[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnValueChanged(float puntuacion) {
        textPuntuacion.text = puntuacion.ToString();
        slider_.value = puntuacion;
        if (puntuacion > puntosEstrella[0] && puntuacion < puntosEstrella[1]) {
            stars[1].sprite = activateStar[1];
        }
        else if (puntuacion > puntosEstrella[1]) {
            stars[2].sprite = activateStar[1];
        }
    }

    internal void Init(int maxPuntuacion)
    {
        slider_.minValue = 0;
        slider_.maxValue = maxPuntuacion;
        puntosEstrella[0] = (maxPuntuacion * 2) / 3;
        puntosEstrella[1] = maxPuntuacion;
    }
}

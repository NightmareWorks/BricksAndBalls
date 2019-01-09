using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarsUI : MonoBehaviour
{
    public Image[] stars = new Image[3];
    bool[] starsActive = new bool[3];
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
        ActivateStar(0);
        stars[1].sprite = activateStar[0];
        stars[2].sprite = activateStar[0];
    }


    public void OnValueChanged(float puntuacion) {
        textPuntuacion.text = puntuacion.ToString();
        slider_.value = puntuacion;
        if (!starsActive[1] && puntuacion > puntosEstrella[0] && puntuacion < puntosEstrella[1]) {
            ActivateStar(1);
        }
        else if (!starsActive[2] && puntuacion >= puntosEstrella[1]) {
            ActivateStar(2);
        }
    }

    internal void Init(int maxPuntuacion)
    {
        slider_.minValue = 0;
        slider_.maxValue = maxPuntuacion;
        puntosEstrella[0] = (maxPuntuacion * 2) / 3;
        puntosEstrella[1] = maxPuntuacion;
    }

    //Activa la estrella que pasa como parámetro y reproduce el sonido
    void ActivateStar(int star) {
        starsActive[star] = true;
        stars[star].sprite = activateStar[1];
        stars[star].gameObject.GetComponent<AudioSource>().Play();
    }
}

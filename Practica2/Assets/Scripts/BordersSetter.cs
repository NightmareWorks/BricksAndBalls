using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersSetter : MonoBehaviour {

    public BoxCollider2D top, right, left, bot;
    public RectTransform[] bordesPantalla = new RectTransform[4];
    float tamX, MarginY,MarginX;
	// Use this for initialization
	void Awake () {
        tamX = Mathf.Min(((float)Screen.width) / 11, ((float)Screen.height) / 18);
        MarginX = (Screen.width - tamX * 11) / 2;
        MarginY = (Screen.height - tamX * 14) / 2;
        Vector3 m = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - MarginX, Screen.height - MarginY, 0));

        Vector3 auxTam = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-MarginX*2, 1, Camera.main.nearClipPlane)) - Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        top.gameObject.transform.localScale = auxTam;
        bot.gameObject.transform.localScale = auxTam;
        top.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height-MarginY, 0));
        bot.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, MarginY, 0));

        //Bordes de la pantalla CANVAS
        bordesPantalla[0].sizeDelta = new Vector2(Screen.width, MarginY); //Top
        bordesPantalla[1].sizeDelta = new Vector2(Screen.width-MarginX*2, Screen.height-MarginY*2);//Juego
        bordesPantalla[2].sizeDelta = new Vector2(Screen.width, MarginY);//Bottom

        auxTam = Camera.main.ScreenToWorldPoint(new Vector3(1, Screen.height-MarginY*2, Camera.main.nearClipPlane)) - Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)); ;
        left.gameObject.transform.localScale = auxTam;
        right.gameObject.transform.localScale = auxTam;
        left.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - MarginX, Screen.height / 2, 0));
        right.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(MarginX, Screen.height / 2, 0));

    }
}

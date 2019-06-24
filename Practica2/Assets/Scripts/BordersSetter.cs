using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// BordersSetter class.
/// Contiene los métodos que posicionan los bordes y UI del juego.
/// </summary>
public class BordersSetter : MonoBehaviour {

    public BoxCollider2D top, right, left, bot;
    public RectTransform[] bordesPantalla = new RectTransform[3];
    public RectTransform[] panel = new RectTransform[3];
    public LayoutElement[] bordesLaterales = new LayoutElement[3];

    float tamX, MarginY,MarginX;
	// Use this for initialization
	void Awake () {
       /* tamX = Mathf.Min(((float)Screen.width) / 11, ((float)Screen.height) / 18);
        MarginX = (Screen.width - tamX * 11) / 2;
        MarginY = (Screen.height - tamX * 14) / 2;

        //Tamaño de los tiles en coordenadas del mundo
        Vector3 auxTam = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-MarginX*2, 1, Camera.main.nearClipPlane)) - Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        //Colliders superior e inferior
        top.gameObject.transform.localScale = auxTam;
        bot.gameObject.transform.localScale = auxTam;
        top.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height-MarginY, 0));
        bot.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, MarginY, 0));

        //Colliders derecho e izquierdo
        auxTam = Camera.main.ScreenToWorldPoint(new Vector3(1, Screen.height-MarginY*2, Camera.main.nearClipPlane)) - Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)); ;
        left.gameObject.transform.localScale = auxTam;
        right.gameObject.transform.localScale = auxTam;
        left.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - MarginX, Screen.height / 2, 0));
        right.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(MarginX, Screen.height / 2, 0));

        //Bordes de la pantalla CANVAS
        bordesPantalla[0].sizeDelta = new Vector2(Screen.width, MarginY); //Top
        bordesPantalla[1].sizeDelta = new Vector2(Screen.width, Screen.height-MarginY*2);//Juego
        bordesPantalla[2].sizeDelta = new Vector2(Screen.width, MarginY);//Bottom

        //Bordes del juego laterales
        bordesLaterales[0].minWidth = MarginX;
        bordesLaterales[0].minHeight = Screen.height - MarginY * 2;
        bordesLaterales[1].minWidth = Screen.width - MarginX*2;
        bordesLaterales[1].minHeight = Screen.height - MarginY * 2;
        bordesLaterales[2].minWidth = MarginX;
        bordesLaterales[2].minHeight = Screen.height - MarginY * 2;

        //Escalado del UI
        float scale = Mathf.Min(bordesPantalla[1].sizeDelta.x / panel[0].sizeDelta.x, (MarginY / 2) / panel[0].sizeDelta.y);
        panel[0].localScale = new Vector3(scale, scale, 1);
        scale = Mathf.Min(bordesPantalla[1].sizeDelta.x / panel[1].sizeDelta.x, (MarginY) / panel[1].sizeDelta.y);
        panel[1].localScale = new Vector3(scale, scale, 1);
        panel[2].localScale = new Vector3(scale, scale, 1);*/

    }
}

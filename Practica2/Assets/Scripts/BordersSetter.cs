using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersSetter : MonoBehaviour {

    public GameObject top, right, left, bot;
    public Camera cam;

	// Use this for initialization
	void Start () {

        //Cada borde en su sitio respecto al tamaño de la pantalla
        Vector3 aux;
        Vector2 pixtam;
        pixtam = top.GetComponent<SpriteRenderer>().sprite.rect.size;
        float scaleFactorX = Screen.width / pixtam.x;
        float scaleFactorY = Screen.height / pixtam.y;

        aux = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, -pixtam.x*2 / 3, 0));
        top.transform.position = new Vector3(aux.x, -aux.y, 0);
        top.transform.localScale = new Vector3(scaleFactorX, 1, 1);

        aux = cam.ScreenToWorldPoint(new Vector3(-pixtam.x*2 / 3, Screen.height/2, 0));
        left.transform.position = new Vector3(aux.x, -aux.y, 0);
        left.transform.localScale = new Vector3(1, scaleFactorY, 1);

        /*
        aux = cam.ScreenToWorldPoint(new Vector3(Screen.width + pixtam.x*2 / 3, Screen.height / 2, 0));
        right.transform.position = new Vector3(aux.x, -aux.y, 0);
        right.transform.localScale = new Vector3(1, scaleFactorY, 1);
        */

        aux = cam.ScreenToWorldPoint(new Vector3(cam.scaledPixelWidth + pixtam.x * 2 / 3, cam.scaledPixelHeight / 2, 0));
        right.transform.position = new Vector3(aux.x, -aux.y, 0);
        right.transform.localScale = new Vector3(1, scaleFactorY, 1);

        aux = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height+pixtam.x * 2 / 3, 0));
        bot.transform.position = new Vector3(aux.x, -aux.y, 0);
        bot.transform.localScale = new Vector3(scaleFactorX, 1, 1);
    }
}

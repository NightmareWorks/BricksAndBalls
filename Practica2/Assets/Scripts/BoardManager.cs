using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BoardManager : MonoBehaviour {
    //Matriz de bloques
    private List<Block> _board;
    private int tamY, tamX;
    private int MarginX, MarginY;

    private Vector3 tamScale, posIni;
    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    void Update () {
        if (_board.Count == 0) {
            Debug.Log("Nivel terminado");
        }
	}
    public void DeleteTile(Block b) {
        _board.Remove(b);
        Destroy(b.gameObject);
    }
    public bool StepForwardBlocks() {
        foreach (Block b in _board) {
            if (b.GetFall())
            {
                b.SetPos(b.GetPosX(), b.GetPosY() - 1);
                if (b.GetPosY() < 0)
                    Debug.Log("HAS PERDIDO");
                else if (b.GetPosY() == 0)
                    Debug.Log("DANGER ZONE");
                //Si la resta es menor se acaba el juego.
                b.gameObject.transform.position = new Vector3(-posIni.x + tamScale.x * b.GetPosX(), posIni.y + tamScale.y * b.GetPosY(), 10);
            }
        }
        return true;
    }

    public void SetLevel(int Level)
    {
        _board = GetComponent<ReadMap>().loadMap(Level);
        
        float tamX = Mathf.Min(((float)Screen.width) / 11, ((float)Screen.height) / 14);
        float MarginX = (Screen.width - tamX * 11) / 2;
        float MarginY = (Screen.height - tamX * 14) / 2;
        Vector3 m = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - MarginX, Screen.height - MarginY, 0));
        //Tamaño al que escalar
        tamScale = Camera.main.ScreenToWorldPoint(new Vector3(tamX, tamX, Camera.main.nearClipPlane)) - Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)); ;

        //Esquina inferior izquierda
        Vector3 CameraCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        //Posicion  de la esquina inferior para un tile
        //Vector3 posIni = new Vector3(CameraCenter.x - tamScale.x/2, -CameraCenter.y + (3*tamScale.y)/2 ,10);

        //Posicion 0,0 del tablero
        posIni = new Vector3(m.x - tamScale.x / 2, -m.y + (3 * tamScale.y) / 2, 10);

        foreach (Block b in _board)
        {
            b.gameObject.transform.localScale = tamScale;
            b.gameObject.transform.position = new Vector3(-posIni.x + tamScale.x * b.GetPosX(), posIni.y + tamScale.y * b.GetPosY(), 10);
        }
   
    }
}

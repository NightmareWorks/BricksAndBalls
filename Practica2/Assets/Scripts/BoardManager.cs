using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class BoardManager : MonoBehaviour {
    //Matriz de bloques
    private List<Block> _board;
    private float tamX;
    private float MarginX, MarginY;
    [SerializeField]
    private ParticleSystem ParticleSystem;
    private Vector3 tamScale, posIni;
    bool levelFinished=false;
    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    void Update () {
        if (!levelFinished && _board.Count == 0) {
            LevelManager.instance.ChangeState(LevelState.NEXT);
        }
	}
    public void DeleteTile(Block b) {
        _board.Remove(b);
        Instantiate(ParticleSystem,b.transform.position,Quaternion.identity);
        Destroy(b.gameObject);
        LevelManager.instance.IncrementPoints();
    }
    public bool StepForwardBlocks() {
        foreach (Block b in _board) {
            if (b.GetFall())
            {
                b.SetPos(b.GetPosX(), b.GetPosY() - 1);
                if (b.GetPosY() < 0)
                {
                    LevelManager.instance.ChangeState(LevelState.DEAD);
                }
                else if (b.GetPosY() == 0)
                    LevelManager.instance.ChangeState(LevelState.DANGER);
                //Si la resta es menor se acaba el juego.
                b.gameObject.transform.position = new Vector3(-posIni.x + tamScale.x * b.GetPosX(), posIni.y + tamScale.y * b.GetPosY(), 10);
            }
        }
        return true;
    }

    public void SetLevel(uint Level)
    {
        _board = GetComponent<ReadMap>().loadMap(Level+1);

        tamX = Mathf.Min(((float)Screen.width) / 11, ((float)Screen.height) / 18);
        MarginX = (Screen.width - tamX * 11) / 2;
        MarginY = (Screen.height - tamX * 14) / 2;

        //Tamaño del tablero de juego en coordenadas del mundo
        Vector3 tamJuego = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - MarginX, Screen.height - MarginY, 0));

        //Tamaño al que escalar
        tamScale = Camera.main.ScreenToWorldPoint(new Vector3(tamX, tamX, Camera.main.nearClipPlane)) - Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)); ;

        //Posicion 0,0 del tablero
        posIni = new Vector3(tamJuego.x - tamScale.x / 2, -tamJuego.y + (3 * tamScale.y) / 2, 10);

        foreach (Block b in _board)
        {
            b.gameObject.transform.localScale = tamScale;
            b.gameObject.transform.position = new Vector3(-posIni.x + tamScale.x * b.GetPosX(), posIni.y + tamScale.y * b.GetPosY(), 10);
        }
   
    }

    internal void DeleteRow()
    {
        List<Block> aux = new List<Block>();
        bool changeLine = false;
        int i = 0;
        int line = _board[0].GetPosY();
        while (!changeLine) {
            if(line != _board[i].GetPosY()) {
                changeLine = true;
            }
            else {
                aux.Add(_board[i]);
            }
        }
        foreach(Block b in aux) {
            DeleteTile(b);
        }
    }

    internal void Earthqueake()
    {
        foreach (Block b in _board)
        {
            //if(b!=null)
            b.SubstractLife(GameManager.instance.r.Next(b.GetLife()));
        }
    }

    public void DestroyBoard()
    {
        foreach(Block b in _board) {
            Destroy(b.gameObject);
        }
    }
    public Vector3 GetTam() {
        return tamScale;
    }
    public int numTiles() {
        return _board.Count;
    }
}
//Esquina inferior izquierda
//Vector3 CameraCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
//Posicion  de la esquina inferior para un tile
//Vector3 posIni = new Vector3(CameraCenter.x - tamScale.x/2, -CameraCenter.y + (3*tamScale.y)/2 ,10);

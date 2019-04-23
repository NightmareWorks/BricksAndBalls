using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class BoardManager : MonoBehaviour {
    //Matriz de bloques
    private List<Block> _board;
    private float tamX;
    public ParticleSystem ParticleSystem;
    private Vector3 posIni;
    bool levelFinished = false;
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
                    Debug.Log("DEAD");
                }
                else if (b.GetPosY() == 0)
                {
                    LevelManager.instance.ChangeState(LevelState.DANGER);
                    Debug.Log("DANGER");
                }
                //Si la resta es menor se acaba el juego.
                b.gameObject.transform.position = new Vector3(-posIni.x + b.GetPosX(), posIni.y + b.GetPosY(), 10);
            }
        }
        return true;
    }

    public void SetLevel(uint Level)
    {
        _board = GetComponent<ReadMap>().loadMap(Level+1);

        //Posicion 0,0 del tablero
        posIni = new Vector3(5, (float)-5.5, 10);

        foreach (Block b in _board)
        {
            b.gameObject.transform.position = new Vector3(-posIni.x + b.GetPosX(), posIni.y + b.GetPosY(), 10);
        }
   
    }

    internal void DeleteRow()
    {
        /*List<Block> aux = new List<Block>();
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
            i++;
        }
        foreach(Block b in aux) {
            DeleteTile(b);
        }*/
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

    public int numTiles() {
        return _board.Count;
    }
}
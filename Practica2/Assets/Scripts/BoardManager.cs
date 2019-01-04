using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BoardManager : MonoBehaviour {
    //Matriz de bloques
    private List<Block> _board;
    private int tamY, tamX;
    

    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    void Update () {
		
	}
    bool StepForwardBlocks() {
        foreach (Block block in _board) {
            
        }
        return true;
    }
    public void SetLevel(List<Block> blocks)
    {
        _board = blocks;
   
    }
}

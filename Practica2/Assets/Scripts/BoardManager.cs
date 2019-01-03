using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BoardManager : MonoBehaviour {
    //Matriz de bloques
    private List<Block> _board;
    [Tooltip("Prefab block")]
    public Block block;

    public TextAsset map;

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
    void setLevel(){

    }
}

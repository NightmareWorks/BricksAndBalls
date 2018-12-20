using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    //Matriz de bloques
    private Block[][] _board;
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

        return true;
    }
    void setLevel(){

    }
}

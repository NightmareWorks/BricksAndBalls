using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public BallSpawner bSpawn;
    public BallSink bSink;
    public DeathZone dZone;
    [Range(1,312)]
    public int Level = 1;

    private uint _numBalls;


	// Use this for initialization
	void Start () {
        GetComponent<ReadMap>().loadMap(Level);
        //Prueba de elementos
        bSink.hide();
        dZone.init(bSink);
        _numBalls = 20;
        bSpawn.setLaunchPos(0, -6);
        bSpawn.spawnBalls(_numBalls);

	}
	
	// Update is called once per frame
	/*void Update () {
		
	}*/
}

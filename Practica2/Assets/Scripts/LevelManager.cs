using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public BallSpawner bSpawn;
    public BallSink bSink;
    public DeathZone dZone;

    public RectTransform CanvasJuego;

    [Range(1,312)]
    public int Level = 1;

    private uint _numBalls;


	// Use this for initialization
	void Start () {
        int i = (int)CanvasJuego.rect.width /11;
        int margenX = (int)CanvasJuego.rect.width % 11;
        List<Block> blocks =  GetComponent<ReadMap>().loadMap(Level);
        foreach (Block b in blocks)
        {
            b.gameObject.transform.position = new Vector3(b.GetPosX(), GetComponent<ReadMap>().y - b.GetPosY(), 0);
        }

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

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

    List<Block> blocks;
    // Use this for initialization
    void Start () {
        blocks =  GetComponent<ReadMap>().loadMap(Level);
                
        //Prueba de elementos
        bSink.hide();
        dZone.init(bSink);
        _numBalls = 20;
        bSpawn.setLaunchPos(0, -6);
        bSpawn.spawnBalls(_numBalls);

        int i = Screen.width;
        int j = Screen.height;
        
        float tamX = Mathf.Min(((float)Screen.width) / 11, ((float)Screen.height) / 14);
        float MarginX = (Screen.width - tamX*11)/2;
        float MarginY = (Screen.height - tamX*14)/2;
        Vector3 m = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - MarginX,Screen.height - MarginY, 0));
        //Tamaño al que escalar
        Vector3 auxTam = Camera.main.ScreenToWorldPoint(new Vector3(tamX, tamX, Camera.main.nearClipPlane)) - Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)); ;

        //Esquina inferior izquierda
        Vector3 CameraCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        //Posicion  de la esquina inferior para un tile
        //Vector3 posIni = new Vector3(CameraCenter.x - auxTam.x/2, -CameraCenter.y + (3*auxTam.y)/2 ,10);

        //Posicion 0,0 del tablero
        Vector3 posIni = new Vector3(m.x - auxTam.x/2, -m.y + (3*auxTam.y)/2 ,10);

        foreach (Block b in blocks)
        {
            b.gameObject.transform.localScale = auxTam;
            b.gameObject.transform.position = new Vector3(-posIni.x + auxTam.x * b.GetPosX(), posIni.y + auxTam.y * b.GetPosY(), 10);
        }

	}
	
	// Update is called once per frame
	void Update () {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LevelState { PLAY, PAUSE, DANGER, DEAD};
public class LevelManager : MonoBehaviour {
    public static LevelManager instance = null;
    private BallSpawner bSpawn;
    private BallSink bSink;
    public DeathZone dZone;
    public Advertising adv;
    public TouchDetect tDetect;

    private LevelState State;

    [Range(1,312)]
    public int Level = 1;

    private uint _numBalls;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        bSink = GetComponent<BallSink>();

        //Call the InitGame function to initialize the first level 
        //InitGame();
    }

    // Use this for initialization
    void Start () {
        bSpawn = this.gameObject.GetComponent<BallSpawner>();
        //Carga el txt del nivel seleccionado
        GetComponent<BoardManager>().SetLevel(Level);

        // 1.Empieza el nivel y coloca el bSink y el bSpawn, se añade una estrella al score
        bSink.hide();
        dZone.init(bSink);

        //Game Manager
        _numBalls = 50;

        Vector3 tam = GetComponent<BoardManager>().GetTam();

        bSpawn.setScale(tam);
        bSpawn.setLaunchPos(0, dZone.gameObject.transform.position.y);
        bSink.setPos(0, dZone.gameObject.transform.position.y);
        bSink.setNumBalls(_numBalls);
        bSink.show();
        bSink.init(tam);
        ///Hay que añadir una estrella a la puntuación 

        // 2.Se activa el detector de pulsación
        tDetect.init(this,bSpawn);
	}
	
    void activateTouch() {
        tDetect.enabled = true;
    }

    void deactivateTouch() {
        tDetect.enabled = false;
    }
    public void ChangeState(LevelState state) {
        State = state;
     }
    public void onLastBallArrived() {
        Vector2 pos = bSink.getPos();
        bSpawn.setLaunchPos(pos.x, pos.y);
        bSpawn.gameObject.SetActive(true);
        tDetect.gameObject.SetActive(true);
        GetComponent<BoardManager>().StepForwardBlocks();
    }

    public uint GetNumBalls() { return _numBalls; }

    public void hideBallSink() { bSink.hide(); }
}

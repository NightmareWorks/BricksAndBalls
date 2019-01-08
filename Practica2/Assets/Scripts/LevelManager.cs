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
    public UIManager UIManager;


    private BoardManager boardManager;

    private LevelState State;

    [Range(1,312)]
    public int Level = 1;
    private int Puntuacion = 0;
    private int PAcumulado = 10;
    private int maxPuntuacion;
    
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
        boardManager = GetComponent<BoardManager>();
        bSpawn = this.gameObject.GetComponent<BallSpawner>();
        //Carga el txt del nivel seleccionado
        boardManager.SetLevel(Level);

        // 1.Empieza el nivel y coloca el bSink y el bSpawn, se añade una estrella al score
        bSink.hide();
        dZone.init(bSink);

        //Game Manager
        _numBalls = 50;

        Vector3 tam = boardManager.GetTam();
        bSpawn.setScale(tam);
        bSpawn.setLaunchPos(0, dZone.gameObject.transform.position.y);
        bSink.init(tam);
        bSink.setPos(0, dZone.gameObject.transform.position.y);
        bSink.setNumBalls(_numBalls);
        bSink.show();
        ///Hay que añadir una estrella a la puntuación 

        // 2.Se activa el detector de pulsación
        tDetect.init(this,bSpawn);

        //Ponemos la máxima puntuación en función del número de bloques
        maxPuntuacion = boardManager.numTiles() * 35;
        UIManager.InitPuntuacion(maxPuntuacion);
	}
    public void IncrementPoints() {
        Puntuacion += PAcumulado;
        PAcumulado += 10;
        UIManager.PuntuacionChanged(Puntuacion);
    }
    public void LaunchBalls(Vector2 direction)
    {
        UIManager.toggleBottomMenu();
        bSpawn.spawnBalls(GetNumBalls(), direction);
        hideBallSink();

    }
    public void onLastBallArrived() {
        Vector2 pos = bSink.getPos();
        bSpawn.setLaunchPos(pos.x, pos.y);
        bSpawn.gameObject.SetActive(true);
        tDetect.gameObject.SetActive(true);
        boardManager.StepForwardBlocks();
        PAcumulado = 10;

        UIManager.toggleBottomMenu();
    }
    public void ChangeState(LevelState state) {
        State = state;
    }
    //Métodos que activan y desactivan el TOUCH
    void activateTouch() {
        tDetect.enabled = true;
    }
    
    void deactivateTouch() {
        tDetect.enabled = false;
    }

    public uint GetNumBalls() { return _numBalls; }

    public void hideBallSink() { bSink.hide(); }
}

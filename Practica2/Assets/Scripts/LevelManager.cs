using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LevelState { PLAY, LAUNCHED, FAST, PAUSE, DANGER, DEAD};
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

    private int framesTurno = 0;
    
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
        dZone.Init(bSink);

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
        tDetect.Init(bSpawn);

        //Ponemos la máxima puntuación en función del número de bloques
        maxPuntuacion = boardManager.numTiles() * 35;
        UIManager.InitPuntuacion(maxPuntuacion);
	}

    private void Update()
    {
        if(State == LevelState.LAUNCHED) {
            if(Time.frameCount - framesTurno > 300) {
                ChangeState(LevelState.FAST);
            }
        }
    }

    public void IncrementPoints() {
        Puntuacion += PAcumulado;
        PAcumulado += 10;
        UIManager.PuntuacionChanged(Puntuacion);
    }

    //Nuevo turno
    public void LaunchBalls(Vector2 direction)
    {
        framesTurno = Time.frameCount;
        ChangeState(LevelState.LAUNCHED);
        UIManager.ToggleBottomMenu();
        bSpawn.spawnBalls(GetNumBalls(), direction);
        HideBallSink();
    }

    //Fin del turno
    public void OnLastBallArrived() {
        Vector2 pos = bSink.getPos();
        bSpawn.setLaunchPos(pos.x, pos.y);
        bSpawn.gameObject.SetActive(true);
        tDetect.gameObject.SetActive(true);
        boardManager.StepForwardBlocks();
        PAcumulado = 10;
        ChangeState(LevelState.PLAY);
       UIManager.ToggleBottomMenu();
    }

    public void ChangeState(LevelState state) {
        State = state;
        switch (State)
        {
            case LevelState.PLAY:
                ActivateTouch();
                Time.timeScale = 1;
                break;
            case LevelState.FAST:
                Time.timeScale = 2;
                break;
            case LevelState.PAUSE:
                DeactivateTouch();
                Time.timeScale = 0;
                break;
            case LevelState.DANGER:
                break;
            case LevelState.DEAD:
                break;

        }
    }

    //Métodos que activan y desactivan el TOUCH
    void ActivateTouch() {
        tDetect.enabled = true;
    }
    
    void DeactivateTouch() {
        tDetect.enabled = false;
    }

    public uint GetNumBalls() { return _numBalls; }

    public void HideBallSink() { bSink.hide(); }
    public void SetState(LevelState state) {
        State = state;
    }
}

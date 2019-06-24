using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelState { PLAY, LAUNCHED, FAST, PAUSE, DANGER, DEAD, NEXT};
public class LevelManager : MonoBehaviour {
    public static LevelManager instance = null;

    public DeathZone dZone;
    public Advertising adv;
    public TouchDetect tDetect;
    public UIManager UIManager;

    public uint stars = 0;

    //Ball spawner and ballsink variables
    private BallSpawner bSpawn;
    private BallSink bSink;
    private Vector3 PosIni = new Vector3(0,-6.5f,0);


    //The level manager has a pointer to each ball
    //in case it has to call destroyAllBalls() or allBallsToSink()
    private List<Ball> _balls = new List<Ball>();

    //////////////////////////////////////

    public bool changeLevel = false;

    private BoardManager boardManager;

    private LevelState State = LevelState.PLAY;

    private uint Level = 1;
    private int Puntuacion = 0;
    private int PAcumulado = 10;
    private int maxPuntuacion;
    private int _powerUpBalls = 0;

    private int framesTurno = 0;

    internal LevelState GetState()
    {
        return State;
    }

    //Total balls 
    private uint _numBalls;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        bSink = GetComponent<BallSink>();
        boardManager = GetComponent<BoardManager>();
        bSpawn = GetComponent<BallSpawner>();
        //Call the InitGame function to initialize the first level 
        //InitGame();
    }

    // Use this for initialization
    void Start () {
        Level = GameManager.instance.GetLevelAct();
        ChangeState(LevelState.PLAY);
        //Carga el txt del nivel seleccionado
        boardManager.SetLevel(Level);

        //Empieza el nivel y coloca el bSink y el bSpawn, se añade una estrella al score
        bSink.hide();
        dZone.Init(bSink);

        //Game Manager
        _numBalls = 50;
        ResetBallAndSinkPos();

        bSink.Init();
        
        // 2.Se activa el detector de pulsación
        tDetect.Init(bSpawn, 6.5f);

        //Ponemos la máxima puntuación en función del número de bloques
        maxPuntuacion = boardManager.numTiles() * 35;
        UIManager.InitPuntuacion(maxPuntuacion);
	}

    internal void PowerUpNewBall()
    {
        _numBalls++;
        _powerUpBalls++;
        bSink.setNumBalls(_numBalls);
        bSink.allBallsArrived();
    }

    internal void DeleteRow()
    {
        boardManager.DeleteRow();
    }

    internal void Earthquake()
    {
        boardManager.Earthquake();
    }


    private void Update()
    {
        if(State == LevelState.LAUNCHED) {
            float time = Time.frameCount;
            if(Mathf.Abs(Time.frameCount - framesTurno) > 350)
                ChangeState(LevelState.FAST);
        }
    }


    /// <summary>
    /// Ball managing methods
    /// </summary>
    uint ballWait=0;
    public void AddNewBall(uint num) {
        ballWait+=num;
    }
    public void PushBall(Ball b)
    {
        _balls.Add(b);
    }

    public void DestroyAllBalls()
    {
        //Hay que parar la corrutina para que no sigan saliendo más bolas
        bSpawn.StopSpawningBalls();
        foreach (Ball b in _balls)
        {
            if (b != null)
                Destroy(b.gameObject);
        }
    }

    public void StopAllBalls()
    {
        //Stops the launching routine
        bSpawn.StopSpawningBalls();
        foreach (Ball b in _balls)
        {
            if (b != null)
            {
                b.Stop();
                b.disableCollision();
            }
        }
    }

    public void AllBallsToSink()
    {
        foreach (Ball b in _balls)
        {
            if (b != null)
            {
                b.MoveToPoint(bSink.getPos(), 30, dZone.LlegaBola);
            }
        }
    }

    public void OneBallLessInBallSink()
    {
        bSink.setNumBalls(bSink.getNumBalls() - 1);
    }

    public void OneBallMoreInBallSink()
    {
        bSink.setNumBalls(bSink.getNumBalls() + 1);
    }


    public void IncrementPoints() {
        Puntuacion += PAcumulado;
        PAcumulado += 10;
        UIManager.PuntuacionChanged(Puntuacion);
    }
    public void ResetPuntuacion()
    {
        Puntuacion = 0;
        UIManager.PuntuacionChanged(Puntuacion);
    }

    //New turn
    public void LaunchBalls(Vector2 direction)
    {
        framesTurno = Time.frameCount;
        ChangeState(LevelState.LAUNCHED);
        UIManager.activateMenuOnThrow();
        bSpawn.spawnBalls(GetNumBalls(), direction);
        bSink.bSinkCeroBallsArrived();
        HideBallSink();
    }

    //Called from the death zone when the last ball arrives
    public void OnLastBallArrived() {
        _numBalls += ballWait;
        _numBalls -= (uint)_powerUpBalls;
        _powerUpBalls = 0;

        ballWait = 0;
        bSink.setNumBalls(_numBalls);

        Vector2 pos = bSink.getPos();
        bSpawn.setLaunchPos(pos.x, pos.y);
        bSpawn.gameObject.SetActive(true);
        bSink.allBallsArrived();
        bSink.show();
        ActivateTouch();

        boardManager.StepForwardBlocks();
        PAcumulado = 10;
        if (changeLevel)
        {
            GameManager.instance.UnlockLevel();
            //SaveManager.Instance.Save();
            UIManager.VictoryPopUp();
            DeactivateTouch();
        }
        ChangeState(LevelState.PLAY);
        UIManager.activateMenuWaiting();
    }

    public void ChangeState(LevelState state) {
        State = state;
        switch (State)
        {
            case LevelState.PLAY:
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
                UIManager.StartWarning();
                break;
            case LevelState.NEXT:
                changeLevel = true;
                break;
            case LevelState.DEAD:
                UIManager.DefeatPopUp();
                break;
        }
    }

    public void NextLevel() {
        stars = 0;
        Level = GameManager.instance.GetLevelAct();
        boardManager.DestroyBoard();
        boardManager.SetLevel(Level);
        UIManager.Restart();
        ChangeState(LevelState.PLAY);
        changeLevel = false;

        _numBalls = 50;

        //Sets the ballSpawner and sink in the center again
        ResetBallAndSinkPos();

        bSink.allBallsArrived();
        UIManager.activateMenuWaiting();
        ActivateTouch();

    }

    public void RestartLevel() {
        //Needs to stop the ball spawner
        stars = 0;
        DestroyAllBalls();
        bSink.setNumBalls(50);//Resets ballSink
        gameObject.SetActive(true);

        Level = GameManager.instance.GetLevelAct();
        boardManager.DestroyBoard();
        boardManager.SetLevel(Level);
        ChangeState(LevelState.PLAY);
        changeLevel = false;

        _numBalls = 50;

        //Sets the ballSpawner and sink in the center again
        ResetBallAndSinkPos();
        bSink.allBallsArrived();
        bSink.show();
        UIManager.activateMenuWaiting();
    }

    //Métodos que activan y desactivan el TOUCH
    public void ActivateTouch() {
        tDetect.gameObject.SetActive(true);
    }
    
    public void DeactivateTouch() {
        tDetect.gameObject.SetActive(false);
    }


    public BoardManager GetBoardManager() {
        return boardManager;
    }

    public uint GetNumBalls() { return _numBalls; }

    public void HideBallSink() { bSink.hide(); }

    public void AddStar() {
        stars++;
    }
    private void ResetBallAndSinkPos()
    {
        bSpawn.setLaunchPos(PosIni.x, PosIni.y);
        bSink.setPos(PosIni.x, PosIni.y);
    }

    public void StopWarning() {
        UIManager.StopWarning();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSink : MonoBehaviour {

    //These objects are GUI
    public GameObject fakeBall;//Non playable ball that is drawn in the sink
    public TextMesh numballsText;//Text placed next to the fakeBall

    
    private uint _numBalls;//Balls actually in the sink
    private uint _ballsArrived;//Balls that have arrived to the sink
    private Vector2 pos;//Position of the sink 2D
    private Vector2 size;//Size of the ball

    /// <summary>
    /// Called when the balls start to be launch
    /// </summary>
    public void hide() {
        fakeBall.SetActive(false);
    }

    /// <summary>
    /// Called when the first ball arrives
    /// </summary>
    public void show()
    {
        fakeBall.SetActive(true);
    }

    /// <summary>
    /// Called when the balls start to be launch
    /// </summary>
    public void init(Vector3 tam)
    {
        fakeBall.gameObject.transform.localScale = tam;
        size = fakeBall.gameObject.GetComponent<SpriteRenderer>().size/2;
        _ballsArrived = LevelManager.instance.GetNumBalls();
    }

    //Gets the ball sink position
    public Vector2 getPos() { return pos; }

    //Sets it
    public void setPos(float x, float y) {
        pos = new Vector2(x, y+size.y);
        fakeBall.gameObject.transform.position = new Vector3(pos.x, pos.y, 0);
    }

    public void setPosX(float x)
    {
        pos = new Vector2(x, pos.y);
        fakeBall.gameObject.transform.position = new Vector3(pos.x, pos.y, 0);
    }


    //Changes the text of the number of balls (called when every ball arrives)
    public void setNumBalls(uint n) {
        _numBalls = n; 
    }

    public void bSinkCeroBallsArrived() {
        _ballsArrived = 0;
        numballsText.text = "x" + _ballsArrived.ToString();
    }

    public void bSinkBallArrived() {
        _ballsArrived++;
        numballsText.text = "x" + _ballsArrived.ToString();
        setNumBalls(_numBalls + 1);
    }

    public void allBallsArrived() {
        _ballsArrived = LevelManager.instance.GetNumBalls();
        numballsText.text = "x" + _ballsArrived.ToString();
    }

    //Gets the number of balls arrived
    public uint getNumBalls() { return _numBalls; }
}

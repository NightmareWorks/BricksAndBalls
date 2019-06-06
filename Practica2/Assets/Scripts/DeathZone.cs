using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    // Use this for initialization
    /*void Start () {
		
	}*/

    // Update is called once per frame
    /*void Update () {
		
	}*/

    //Initializes it with the ballSink it needs to work
    public void Init(BallSink bs) {
        _bSink = bs;
    }

    /// <summary>
    /// Changes the sink numballs (Called when a ball arrives)
    /// </summary>
    public void LlegaBola() {
        _bSink.bSinkBallArrived();
        //If all balls have arrived
        if (_bSink.getNumBalls() == LevelManager.instance.GetNumBalls())
        {
            LevelManager.instance.OnLastBallArrived();
            firstOne = true;
        }
    }

    /// <summary>
    /// Called when a ball collides with the trigger.
    /// If it's the first ball, activates the sink GUI
    /// For each ball, moves it to the sink, updates the number of balls
    /// and destroys it
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball thisBall = collision.gameObject.GetComponent<Ball>();

        //First of all we make sure the ball is returning
        //and it didn't collided while being launched
        if (thisBall.IsReturning())
        {
            _bSink.show();
            if (firstOne)
            {
                _bSink.setPosX(collision.gameObject.transform.position.x);
                _bSink.bSinkBallArrived();
                Destroy(thisBall.gameObject);
                firstOne = false;
            }
            else
            {
                thisBall.Stop();
                thisBall.MoveToPoint(_bSink.getPos(), 10, LlegaBola);
            }
        }

    }

    public bool firstOne = true;
    private BallSink _bSink;
    private LevelManager _lvMgr;
}

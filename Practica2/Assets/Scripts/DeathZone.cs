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
    public void init(LevelManager lvM,BallSink bs) {
        _lvMgr = lvM;
        _bSink = bs;
    }

    //Changes the sink numballs (Called when a ball arrives)
    public void llegaBola() {
        _bSink.setNumBalls(_bSink.getNumBalls() + 1);
        //If all balls have arrived
        if (_bSink.getNumBalls() == _lvMgr.GetNumBalls())
        {
            _lvMgr.onLastBallArrived();
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
        if (thisBall.isReturning())
        {
            if (firstOne)
            {
                _bSink.setPos(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
                _bSink.setNumBalls(1);
                _bSink.show();
                Destroy(thisBall.gameObject);
                firstOne = false;
            }
            else
            {
                thisBall.stop();
                thisBall.moveToPoint(_bSink.getPos(), 10, llegaBola);
            }
        }
    }

    public bool firstOne = true;
    private BallSink _bSink;
    private LevelManager _lvMgr;
}

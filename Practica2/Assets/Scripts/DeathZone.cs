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
    public void init(BallSink bs) {
        _bSink = bs;
    }

    public void llegaBola() {
        _bSink.setNumBalls(_bSink.getNumBalls() + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball thisBall = collision.gameObject.GetComponent<Ball>();
        if (firstOne)
        {
            _bSink.setPos(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
            _bSink.setNumBalls(1);
            _bSink.show();
            Destroy(thisBall.gameObject);
            firstOne = false;
        }
        else {
            thisBall.stop();
            thisBall.moveToPoint(_bSink.getPos(), 10, llegaBola);
        }
    }

    public bool firstOne = true;
    private BallSink _bSink;
}

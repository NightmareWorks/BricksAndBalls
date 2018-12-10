using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSink : MonoBehaviour {

    public Ball fakeBall;
    public Text numballsText;

    private uint _numBalls;
    private Vector2 pos;

    public void hide() {
        gameObject.SetActive(false);
    }

    public void show()
    {
        gameObject.SetActive(true);
    }

    public Vector2 getPos() { return pos; }
    public void setPos(float x, float y) { pos = new Vector2(x, y);
        fakeBall.gameObject.transform.position = new Vector3(pos.x, pos.y, 0); }
    public void setNumBalls(uint n) { _numBalls = n; numballsText.text = "x" + _numBalls.ToString(); }
    public uint getNumBalls() { return _numBalls; }

    // Use this for initialization
    /*void Start () {
		
	}*/

    // Update is called once per frame
    /*void Update () {
		
	}*/
}

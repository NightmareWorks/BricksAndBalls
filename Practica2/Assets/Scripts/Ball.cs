using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    /*void Update () {
		
	}*/

    public void startMove() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(5,50));
    }

    public void stop() {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void moveToPoint(float x, float y)
    {
    }
}

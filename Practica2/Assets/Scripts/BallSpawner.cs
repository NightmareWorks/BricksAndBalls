using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    public GameObject ball;
    public int numBalls;
    // Use this for initialization
    void Start () {
        //ball1 = Instantiate(ball);
        //ball2 = Instantiate(ball);
        numBalls = 10;
        StartCoroutine(spawnBalls());
    }
	
	// Update is called once per frame
	void Update () {
        //Intento chusco
        if (Input.GetKeyUp(KeyCode.C))
        {
            //ball1.GetComponent<Ball>().startMove();
        }
        else if (Input.GetKeyUp(KeyCode.V))
        {
            //ball2.GetComponent<Ball>().startMove();
        }
    }

    IEnumerator spawnBalls()
    {
        for (int i = 0; i < numBalls; i++)
        {
            GameObject actB = Instantiate(ball);
            actB.GetComponent<Ball>().startMove();
            yield return new WaitForSeconds(.1f);
        }
    }


}

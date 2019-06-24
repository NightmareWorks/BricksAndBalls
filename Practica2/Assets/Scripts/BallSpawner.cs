using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    public Ball ball;
    private Transform parent;
    //public int numBalls;
    // Use this for initialization
    void Start () {
        parent = new GameObject("Balls").transform;
    }


    //Falta la dirección que van a tomar las bolas
    public void spawnBalls(uint numBalls, Vector2 direction) {
        StartCoroutine(spawnBallsCoroutine(numBalls, direction));
    }

    public void setLaunchPos(float x, float y) {
        posX = x; posY = y;
    }
    public void setLaunchPosX(float x)
    {
        posX = x;
    }
    public Vector2 getLaunchPos()
    {
        return new Vector2(posX, posY);
    }

    IEnumerator spawnBallsCoroutine(uint numBalls, Vector2 direction)
    {
        for (int i = 0; i < numBalls; i++)
        {
            Ball actB = Instantiate(ball,parent);
            LevelManager.instance.PushBall(actB);
            actB.init();
            actB.startMove(new Vector2(posX,posY),speed * direction);
            LevelManager.instance.OneBallLessInBallSink();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
        }
        gameObject.SetActive(false);
    }

    public void StopSpawningBalls() {
        StopAllCoroutines();
    }

    private float posX, posY;
    private float speed = 50;
}

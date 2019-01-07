using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


    // Use this for initialization
    /*void Start () {
    }*/

    // Update is called once per frame
    /*void Update () {
		
	}*/
    public void init(Vector3 tam) {
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.localScale = tam;
    }

    public void startMove(Vector2 posIni, Vector2 speed) {
        transform.position/*.Set(posIni.x, posIni.y, 0);*/
            = new Vector3(posIni.x, posIni.y, 0);
        rb.AddForce(/*new Vector2(5,50)*/speed);
    }

    public void stop() {
        rb.velocity = Vector3.zero;
    }

    public void moveToPoint(Vector2 position, uint numPasos, System.Action callback = null)
    {
        StartCoroutine(moveToCoroutine(position, numPasos, callback));
    }

    //A este método se le puede pasar un Callback para que lo lance cuando haya terminado
    private IEnumerator moveToCoroutine(Vector2 position, uint numPasos, System.Action callback) {
        Vector2 moveTo = new Vector2((position.x - transform.position.x) / numPasos, (position.y - transform.position.y)/numPasos);
        for (int i = 0; i < numPasos; i++) {
            transform.position = new Vector3(transform.position.x + moveTo.x, transform.position.y + moveTo.y, 0);
            yield return new WaitForSeconds(.01f);
        }
        callback();
        Destroy(gameObject);
    }

    public bool isReturning() {
        return rb.velocity.y < 0;
    }

    private Rigidbody2D rb;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody2D rb;
    bool moving= false;
    int wait = 0;

    public void enableCollision()
    {
        if (rb != null)
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
            rb.WakeUp();
        }
    }

    public void disableCollision()
    {
        if (rb != null)
        {
            rb.Sleep();
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }

    public void init() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void startMove(Vector2 posIni, Vector2 speed) {
        transform.position = new Vector3(posIni.x, posIni.y, 0);
        rb.AddForce(speed);
        moving = true;

    }

    public void Stop() {
        rb.velocity = Vector3.zero;
        moving = false;
        wait = 0;
    }

    public void MoveToPoint(Vector2 position, uint numPasos, System.Action callback = null)
    {
        StartCoroutine(MoveToCoroutine(position, numPasos, callback));
    }

    //A este método se le puede pasar un Callback para que lo lance cuando haya terminado
    private IEnumerator MoveToCoroutine(Vector2 position, uint numPasos, System.Action callback) {
        Vector2 moveTo = new Vector2((position.x - transform.position.x) / numPasos, (position.y - transform.position.y)/numPasos);
        for (int i = 0; i < numPasos; i++) {
            transform.position = new Vector3(transform.position.x + moveTo.x, transform.position.y + moveTo.y, 0);
            yield return new WaitForSeconds(.01f);
        }
        callback();
        Destroy(gameObject);
    }

    public bool IsReturning() {
        return rb.velocity.y < 0;
    }

    public void ChangeDirX() {
        float a = GameManager.instance.r.Next((int)-rb.velocity.x*10, (int)rb.velocity.x*10);
        rb.velocity = new Vector2( a / 10, rb.velocity.y);
    }

    private void Update()
    {
        if (moving)
        {
            wait++;
            if (wait % 60 == 0 && Mathf.Abs(rb.velocity.y) <= 0.000001)
            {
                rb.AddForce(new Vector2(0, 10));
            }
        }
    }
}

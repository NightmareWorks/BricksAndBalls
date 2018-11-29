using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {

    private int life;

    [Tooltip("Vida")]
    public Text txt;

	// Use this for initialization
	void Start () {
        life = 5;
        txt.text = life.ToString();
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        --life;
        if (life <= 0) {
            Destroy(gameObject);
        }
        else
            txt.text = life.ToString();
    }
}

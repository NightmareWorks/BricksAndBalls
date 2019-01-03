using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {

    private int _life=0;
    private int _type;
    private bool fall;
    private int posX, posY;
    [Tooltip("Vida")]
    public Text txt;

	// Use this for initialization
	void Start () {
        txt.text = _life.ToString();
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        --_life;
        if (_life <= 0) {
            Destroy(gameObject);
        }
        else
            txt.text = _life.ToString();
    }
    public void SetType(int type) {
        _type = type;
    }
    public void SetLife(int life)
    {
        _life = life;
        txt.text = _life.ToString();
    }
    public void SetPos(int x, int y) {
        posX = x;
        posY = y;
    }
}

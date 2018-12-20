using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {

    private int _life;
    private int _type;
    [Tooltip("Vida")]
    public Text txt;

	// Use this for initialization
	void Start () {
        _life = 5;
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
    public void setType(int type) {
        _type = type;
    }
    public void setLife(int life)
    {
        _life = life;
    }
}

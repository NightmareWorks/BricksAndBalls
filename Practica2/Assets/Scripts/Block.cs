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

    public BoardManager boardManager;

	// Use this for initialization
	void Start () {
    
    }
    public bool GetFall() { return fall; }
    private void OnCollisionExit2D(Collision2D collision)
    {
        --_life;
        if (_life <= 0) {
            boardManager.DeleteTile(this);
        }
        else
            txt.text = _life.ToString();
    }
    public void SetType(int type) {
        _type = type;
        Sprite myBlock = Resources.Load("Images/game_img_block" + type + "_1", typeof(Sprite)) as Sprite;
        gameObject.GetComponent<SpriteRenderer>().sprite = myBlock;
        switch (_type)
        {
            case 10:
            case 20:
                fall = false;
                break;
            default:
                break;
        }
    }
    public void SetLife(int life)
    {
        _life = life;
        if (_type == 2 || _type == 10)
            _life *= 2;

        if(life!=0)
            txt.text = _life.ToString();
    }
    public void SetPos(int x, int y) {
        posX = x;
        posY = y;
    }
    public void invertPosY(int y)
    {
        posY = y-posY;
    }
    public int GetPosX()
    {
        return posX;
    }
    public int GetPosY()
    {
        return posY;
    }
}

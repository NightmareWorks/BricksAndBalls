using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {

    private int _life=0;
    private int _type;
    private bool fall = true;
    private int posX, posY;
    [Tooltip("Vida")]
    public TextMesh txt;
    private AudioSource audioSource;
    private BoardManager boardManager;
    private Logica BlockLogic;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        boardManager = LevelManager.instance.GetBoardManager();
    }

    public bool GetFall() { return fall; }

    private void OnCollisionExit2D(Collision2D collision)
    {
        audioSource.Play();
        if (--_life <= 0)
        {
            BlockLogic.LogicCollision(collision.gameObject);
            boardManager.DeleteTile(this);
        }
        else
        {
            txt.text = _life.ToString();
            UpdateColor();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BlockLogic.LogicTrigger(collision.gameObject);
    }

    public void SetType(int type) {
        _type = type;
        Sprite myBlock = Resources.Load("Images/game_img_block" + type + "_1", typeof(Sprite)) as Sprite;
        gameObject.GetComponent<SpriteRenderer>().sprite = myBlock;
        gameObject.AddComponent<PolygonCollider2D>();
        SetLogic();
    }

    private void SetLogic()
    {
        switch (_type) {
            case 1:
                BlockLogic = gameObject.AddComponent(Type.GetType("Logica1")) as Logica;
                break;
            case 3:
            case 4:
            case 5:
            case 6:
                BlockLogic = gameObject.AddComponent(Type.GetType("Logica3")) as Logica;
                BlockLogic.Initialize(_type);
                break;
            case 21:
            case 22:
            case 23:
                BlockLogic = gameObject.AddComponent(Type.GetType("Logica21")) as Logica;
                BlockLogic.Initialize(_type);
                break;
            case 24:
                BlockLogic = gameObject.AddComponent(Type.GetType("Logica24")) as Logica;
                break;
            default:
                BlockLogic = gameObject.AddComponent(Type.GetType("Logica1")) as Logica;
                break;
        }
    }

    public void SubstractLife(int life) {
        audioSource.Play();
        _life -= life;
        txt.text = _life.ToString();
        UpdateColor();
    }

    public int GetLife() {
        return _life;
    }

    public void SetLife(int life)
    {
        _life = life;
        if (_type == 2 || _type == 10)
            _life *= 2;

        if (life != 0)
        {
            txt.text = _life.ToString();
        }
        UpdateColor();
    }
    private void UpdateColor() {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f - ((_life % 100) / 100.0f), 1.0f - ((_life % 100) / 100.0f), 1.0f - ((_life % 100) / 100.0f));

    }
    public void SetPos(int x, int y) {
        posX = x;
        posY = y;
        mask();
    }

    public void invertPosY(int y)
    {
        posY = y-posY;
        mask();
    }

    public int GetPosX()
    {
        return posX;
    }

    public int GetPosY()
    {
        return posY;
    }

    private void mask()
    {
        if (posY > 11)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
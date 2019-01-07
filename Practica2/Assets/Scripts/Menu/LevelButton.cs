using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    //Initializes the button for choosing the lvl
    public void init(uint level, bool playable, uint numStars = 0)
    {
        _level = level;
        _playable = playable;
        _numStars = numStars;

        Image img = gameObject.GetComponent<Image>();
        Text lvText = gameObject.GetComponentInChildren<Text>();
        if (!_playable)
        {
            _star3.SetActive(false);
            _star2.SetActive(false);
            _star1.SetActive(false);
            img.sprite = _lockedLevel;
            lvText.gameObject.SetActive(false);
            //lvText.text = "";
        }
        else {
            switch (_numStars) {
                case 3:
                    _star3.SetActive(true);
                    _star2.SetActive(true);
                    _star1.SetActive(true);
                    break;
                case 2:
                    _star2.SetActive(true);
                    _star1.SetActive(true);
                    break;
                case 1:
                    _star1.SetActive(true);
                    break;
                default:
                    break;
            }
            lvText.gameObject.SetActive(true);
            lvText.text = _level.ToString();
        }
    }

    public uint getLevel() { return _level; }

    public void goToLevel() {
        //Llama al metodo del menu manager para ir al nivel suyo
        if (_playable)
            Debug.Log("Voy al nivel " + _level);
        else
            Debug.Log("Locked");
    }

    //Sprites for the level button
    [SerializeField]
    private Sprite _lockedLevel;
    [SerializeField]
    private Sprite _unlockedLevel;

    //Sprites for the level score in case it's unlocked
    [SerializeField]
    private GameObject _star1, _star2, _star3;

    private bool _playable = false; //The level can be played already
    private uint _level; //Level number
    private uint _numStars; //Stars achieved in this level
}

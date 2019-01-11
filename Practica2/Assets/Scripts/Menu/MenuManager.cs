using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    //Component that fills the canvas with the level buttons
    private LevelFiller _lvFiller;
    [SerializeField]
    private Level[] _Levels;

    //Window to exit
    [SerializeField]
    private GameObject _exitPopUp;

    //Window to shop
    [SerializeField]
    private GameObject _shopPopUp;
    [SerializeField]
    private GameObject _cantBuyPop;

    //Power ups ingame that can be purchased at the shop
    [SerializeField]
    private Text _numEQ;
    private uint _numEarthQuakes;

    //Number of rubys and stars
    //These ints must be assigned at start()
    //Both can be updated after watching ads or finishing levels
    [SerializeField]
    private Text _rubysTxtShop;
    [SerializeField]
    private Text _rubysTxt;
    private uint _numRubys;
    [SerializeField]
    private Text _starsTxt;
    private uint _totalStars;

    /*
    //Attributes used to create the level buttons
    private LevelButton[] _levelButtons;
    private uint _lvCount;*/

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    public void Init()
    {
        _Levels = GameManager.instance.GetLevels();
        //Initializes the number of buttons and the levelFiller
        /*_levelButtons = new LevelButton[_Levels.Length];
        _lvCount = 0;*/
        _lvFiller = GetComponent<LevelFiller>();
        _lvFiller.init(this, _Levels);

        //Fills the grid with buttons
        _lvFiller.fill();

        //Pregunta si existe archivo de guardado

        //Si lo hay, carga el estado de los niveles, los rubíes y los items




        //Si no lo hay, inicializa el nivel 1 con 0 estrellas, pone 400 rubíes y ningún item
        /*_levelButtons[0].init(1, true);
        for (uint i = 2; i <= _Levels.Length; i++)
        {
            _levelButtons[i - 1].init(i, false);
        }*/


        //Assigns the numbers to respective texts
        _numRubys = GameManager.instance.GetRubies();
        _rubysTxt.text = _numRubys.ToString();
        _rubysTxtShop.text = _numRubys.ToString();
        _starsTxt.text = _totalStars.ToString();

        //Assigns the numbers for the power ups
        _numEarthQuakes = GameManager.instance.GetNumPowerUp(PowerUp.EARTHQUACKE);
        _numEQ.text = _numEarthQuakes.ToString();
    }

    //Introduces a button into the array (called in the filler)
    /*public void pushButton(LevelButton btn)
    {
        _levelButtons[_lvCount] = btn;
        ++_lvCount;
    }*/

    ////Callbacks for the exit button////
    public void showExitPopUp()
    {
        _exitPopUp.SetActive(true);
    }

    public void hideExitPopUp()
    {
        _exitPopUp.SetActive(false);
    }

    public void exitApp()
    {
        Application.Quit();
    }
    //////////////////////////////////////

    ////Callbacks for the shop buttons////
    public void ShowShopPopUp()
    {
        _shopPopUp.SetActive(true);
    }

    public void HideShopPopUp()
    {
        _shopPopUp.SetActive(false);
    }

    public void HideCantBuyPopUp()
    {
        _cantBuyPop.SetActive(false);
    }

    public void BuyEarthquackes()
    {
        if (GameManager.instance.BuyPowerUp(PowerUp.EARTHQUACKE))
        {
            _numRubys = GameManager.instance.GetRubies();
            _rubysTxt.text = _numRubys.ToString();
            _rubysTxtShop.text = _numRubys.ToString();
            _numEarthQuakes = GameManager.instance.GetNumPowerUp(PowerUp.EARTHQUACKE);
            _numEQ.text = _numEarthQuakes.ToString();
        }
        else
        {
            _cantBuyPop.SetActive(true);
        }
    }
    //////////////////////////////////////
    
    ////Callbacks for the ad button////
    public void AdButtonCallback()
    {
        GameManager.instance.ShowAds();
    }

    //This method is called from the advertising class
    public void UpdateRubys(uint n)
    {
        _numRubys = n;
        _rubysTxt.text = _numRubys.ToString();
        _rubysTxtShop.text = _numRubys.ToString();
    }
    //////////////////////////////////////
}
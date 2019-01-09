using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //Component that fills the canvas with the level buttons
    [SerializeField]
    private LevelFiller _lvFiller;
    [SerializeField]
    private uint _numLevels;

    //Window to exit
    [SerializeField]
    private GameObject _exitPopUp;

    //Window to shop
    [SerializeField]
    private GameObject _shopPopUp;
    [SerializeField]
    private GameObject _cantBuyPop;

    //Power ups ingame that cam be purchased at the shop
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

    //Attributes used to create the level buttons
    private LevelButton[] _levelButtons;
    private uint _lvCount;

    //Advertisement component
    private Advertising _ads;

    // Start is called before the first frame update
    void Start()
    {
        //Inits ads
        //_ads = GetComponent<Advertising>();
        //_ads.init(this);

        //Initializes the number of buttons and the levelFiller
        _levelButtons = new LevelButton[_numLevels];
        _lvCount = 0;
        _lvFiller.init(this, _numLevels);

        //Fills the grid with buttons
        _lvFiller.fill();

        //Pregunta si existe archivo de guardado

        //Si lo hay, carga el estado de los niveles, los rubíes y los items




        //Si no lo hay, inicializa el nivel 1 con 0 estrellas, pone 400 rubíes y ningún item
        _levelButtons[1].init(2, true);
        _levelButtons[0].init(1, true);
        for (uint i = 3; i <= _numLevels; i++) {
            _levelButtons[i-1].init(i, false);
        }
        _numRubys = 400;
        _totalStars = 0;

        //Assigns the numbers to respective texts
        _rubysTxt.text = _numRubys.ToString();
        _rubysTxtShop.text = _numRubys.ToString();
        _starsTxt.text = _totalStars.ToString();

        //Assigns the numbers for the power ups
        _numEarthQuakes = 0;
        _numEQ.text = _numEarthQuakes.ToString();
    }

    //Introduces a button into the array (called in the filler)
    public void pushButton(LevelButton btn) {
        _levelButtons[_lvCount] = btn;
        ++_lvCount;
    }

    ////Callbacks for the exit button////
    public void showExitPopUp() {
        _exitPopUp.SetActive(true);
    }

    public void hideExitPopUp() {
        _exitPopUp.SetActive(false);
    }

    public void exitApp() {
        //Guarda las cosas y sale
        Application.Quit();
    }
    //////////////////////////////////////
    
    ////Callbacks for the shop buttons////
    public void showShopPopUp()
    {
        _shopPopUp.SetActive(true);
    }

    public void hideShopPopUp()
    {
        _shopPopUp.SetActive(false);
    }

    public void hideCantBuyPopUp() {
        _cantBuyPop.SetActive(false);
    }

    public void buyEarthquackes()
    {
        if (_numRubys >= 200)
        {
            _numRubys -= 200;
            _rubysTxt.text = _numRubys.ToString();
            _rubysTxtShop.text = _numRubys.ToString();
            _numEarthQuakes++;
            _numEQ.text = _numEarthQuakes.ToString();
        }
        else {
            _cantBuyPop.SetActive(true);
        }
    }
    //////////////////////////////////////
    
    ////Callbacks for the ad button////
    public void adButtonCallback()
    {
        _ads.ShowRewardedAd();
    }

    //This method is called from the advertising class
    public void getRubys(uint n) {
        _numRubys += n;
        _rubysTxt.text = _numRubys.ToString();
        _rubysTxtShop.text = _numRubys.ToString();
    }
    //////////////////////////////////////
}

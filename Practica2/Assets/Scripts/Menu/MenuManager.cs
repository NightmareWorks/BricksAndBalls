using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private LevelFiller _lvFiller;
    [SerializeField]
    private uint _numLevels;
    [SerializeField]
    private GameObject _exitPopUp;

    private LevelButton[] _levelButtons;
    private uint _lvCount;

    // Start is called before the first frame update
    void Start()
    {
        //Initializes the number of buttons and the levelFiller
        _levelButtons = new LevelButton[_numLevels];
        _lvCount = 0;
        _lvFiller.init(this, _numLevels);

        //Fills the grid with buttons
        _lvFiller.fill();

        //Pregunta si existe archivo de guardado

        //Si lo hay, carga el estado de los niveles, los rubíes y los items




        //Si no lo hay, inicializa el nivel 1 con 0 estrellas, pone 400 rubíes y ningún item
        for (uint i = _numLevels - 1; i > 0; i--) {
            _levelButtons[i].init(i+1, false);
        }
        _levelButtons[1].init(2, true);
        _levelButtons[0].init(1, true);

    }

    //Introduces a button into the array (called in the filler)
    public void pushButton(LevelButton btn) {
        _levelButtons[_lvCount] = btn;
        ++_lvCount;
    }

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
}

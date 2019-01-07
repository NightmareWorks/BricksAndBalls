using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFiller : MonoBehaviour
{

    [SerializeField]
    private LevelButton _levelPrefab;

    private uint _numLevels;
    private MenuManager _menuManager;

    //Inits this component with the manager
    //It's needed to push the created buttons into the
    //manager list
    public void init(MenuManager mMgr, uint numLevels )
    {
        _menuManager = mMgr;
        _numLevels = numLevels;

    }

    /// <summary>
    /// Creates and pushes the level buttons into the grid and
    /// the manager list to initialize them later
    /// </summary>    
    public void fill() {
        LevelButton newButton;
        for (int i = 0; i < _numLevels; i++) {
            newButton = (LevelButton)Instantiate(_levelPrefab, transform);
            _menuManager.pushButton(newButton);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFiller : MonoBehaviour
{
    //The level button prefab
    public LevelButton _levelPrefab;

    private Level[] _Levels;
    private MenuManager _menuManager;

    //Needs the parent to set every button position
    public Transform parent;

    //Inits this component with the manager
    //It's needed to push the created buttons into the
    //manager list
    public void init(MenuManager mMgr, Level[] Levels )
    {
        _menuManager = mMgr;
        _Levels = Levels;
    }

    /// <summary>
    /// Creates and pushes the level buttons into the grid and
    /// the manager list to initialize them later
    /// It returns the max number of stars
    /// </summary>    
    public uint Fill() {
        uint maxStars=0;
        LevelButton newButton;
        for (uint i = 0; i < _Levels.Length; i++) {
            newButton = (LevelButton)Instantiate(_levelPrefab, parent);
            newButton.init(i + 1, _Levels[i].playable, _Levels[i].star);
            if (_Levels[i].playable)
                maxStars += _Levels[i].star;
        }
        return maxStars;
    }
}

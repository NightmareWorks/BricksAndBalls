﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PowerUp { EARTHQUACKE, EXTRABALL, DELETE, SIZE =3 }

public struct Level {
    public uint star;
    public bool playable;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //Advertisement component
    private Advertising _ads;

    private uint _maxLevel;
    private uint _totalStars;
    private uint levelAct=0;
    private Level[] _levels; //Loads each level and the number of stars if -1 not activated

    private uint rubies;
    private uint[] powerUps = new uint[(uint)PowerUp.SIZE]; // 0 Earthquackes 1 ExtraBall

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitFromSaved();
        //Inits ads
        _ads = GetComponent<Advertising>();

        //Assigns the numbers for the power ups
        powerUps[(uint)PowerUp.EARTHQUACKE] = 0;
        if(MenuManager.instance != null)
            MenuManager.instance.Init();
    }

    //This is called 
    void InitFromSaved()
    {
        _levels = SaveManager.Instance.GetLevels();
        _maxLevel = SaveManager.Instance.GetMaxLevel();
        powerUps = SaveManager.Instance.GetPowerUp();
        rubies = SaveManager.Instance.GetRubies();
    }

    //Exits the app
    public void ExitApp() {
        SaveManager.Instance.Save();
        Application.Quit();
    }

    //This is called from the menuManager to get 
    //all levels and init the buttons for them
    public Level[] GetLevels() {
        return _levels;
    }
    public uint GetRubies()
    {
        return rubies;
    }
    public void AddRubies(uint addrubi) {
        rubies += addrubi;
        if (MenuManager.instance != null)
        {
            MenuManager.instance.UpdateRubys(rubies);
            MenuManager.instance.UpdateRubys(rubies);
        }
        SaveManager.Instance.Save();
    }
    public uint GetNumPowerUp(PowerUp popUp)
    {
        return powerUps[(int)popUp];
    }

    ////Callbacks for the ad button////
    public void ShowAds()
    {
        _ads.ShowRewardedAd();
    }

    public bool BuyPowerUp(PowerUp powerUp) {
        bool buy = false;
        uint price = 0;
        switch (powerUp) {
            case PowerUp.EARTHQUACKE:
                price = 200;
                break;
            case PowerUp.EXTRABALL:
                price = 100;
                break;
            case PowerUp.DELETE:
                price = 300;
                break;
        }
        if (rubies >= price)
        {
            rubies -= price;
            powerUps[(int)powerUp]++;
            buy = true;
        }
        return buy;
    }
    public void NextLevel() {
        _levels[levelAct].star = LevelManager.instance.stars;
        levelAct++;
        if (levelAct > _maxLevel) _maxLevel = levelAct;

        //ACTUALIZA EL NIVEL DESBLOQUEADO
        _levels[levelAct].playable = true;
        SaveManager.Instance.Save();
        LevelManager.instance.NextLevel();
    }
    public void LoadLevel(uint _level, bool menu = false) {
        levelAct = _level;
        if(menu)
            SceneManager.LoadScene(1);
    }
    public uint GetLevelAct() {
        return levelAct;
    }

    internal uint[] GetPowerUp()
    {
        return powerUps;
    }
    internal uint GetMaxLevel() { return _maxLevel; }


}

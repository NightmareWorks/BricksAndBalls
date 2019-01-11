using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public SaveState state;
    public static SaveManager Instance { set; get; }

    private void Awake()
    {
        Instance = this;
        Load();
        Debug.Log(Helper.Serialize<SaveState>(state));

    }
    public void Save() {
        state.rubies = GameManager.instance.GetRubies();
        state.Levels = GameManager.instance.GetLevels();
        state.PowerUps = GameManager.instance.GetPowerUp();
        state.maxLevel = GameManager.instance.GetMaxLevel();

        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("save")) {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }else {
            state = new SaveState();
            state.Levels[0].playable = true;
            state.Levels[0].star = 0;
            Save();
            Debug.Log("No save filed found, creating a new one!");
        }
    }
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }

    public uint PowerUp(PowerUp powerUp) { 
        return state.PowerUps[(int)powerUp];
    }
    internal Level[] GetLevels() {
        return state.Levels;
    }

    internal uint GetMaxLevel()
    {
        return state.maxLevel;
    }

    internal uint[] GetPowerUp()
    {
        return state.PowerUps;
    }

    internal uint GetRubies()
    {
        return state.rubies;
    }

    internal void SetLevels(Level[] levels)
    {
        state.Levels= levels;
    }

    internal void SetMaxLevel(uint maxLevel)
    {
        state.maxLevel = maxLevel;
    }

    internal void SetPowerUp(uint[] powerUp)
    {   
        state.PowerUps= powerUp;
    }

    internal void SetRubies(uint Rubies)
    {
        state.rubies=Rubies;
    }
}

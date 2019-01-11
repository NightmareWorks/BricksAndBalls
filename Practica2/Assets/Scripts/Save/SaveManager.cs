using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public SaveState state;
    public static SaveManager Instance { set; get; }
    public bool hasStateSaved = false;
    private void Awake()
    {
        //ResetSave();
        Instance = this;
        Load();
        Debug.Log(Helper.Deserialize<SaveState>(Helper.Decrypt(PlayerPrefs.GetString("save"))));

    }
    public void Save() {
        state.rubies = GameManager.instance.GetRubies();
        state.Levels = GameManager.instance.GetLevels();
        state.PowerUps = GameManager.instance.GetPowerUp();
        state.maxLevel = GameManager.instance.GetMaxLevel();

        PlayerPrefs.SetString("save", Helper.Encrypt(Helper.Serialize<SaveState>(state)));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("save")) {
            hasStateSaved = true;
            state = Helper.Deserialize<SaveState>(Helper.Decrypt(PlayerPrefs.GetString("save")));

        }else {
            state = new SaveState();
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

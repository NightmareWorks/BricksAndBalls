﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    //Botones
    public void Pause()
    {
        GetComponent<UIManager>().TogglePausaMenu();
        LevelManager.instance.ChangeState(LevelState.PAUSE);
    }
    public void Play() {
        GetComponent<UIManager>().TogglePausaMenu();
        LevelManager.instance.ChangeState(LevelState.PLAY);
    }
}
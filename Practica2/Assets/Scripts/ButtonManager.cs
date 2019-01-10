using System.Collections;
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
        LevelManager.instance.ActivateTouch();
    }

    public void BackToMenu() {
        Debug.Log("Vuelvo a cargar el menu");
    }

    public void GoToNextLevel() {
        Debug.Log("Al siguiente niv");
        GetComponent<UIManager>().hideVictoryPopUp();
        LevelManager.instance.NextLevel();
        LevelManager.instance.ActivateTouch();
    }
}

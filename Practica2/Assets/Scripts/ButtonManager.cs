using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This component contains the callbacks of all the 
/// gameScene buttons
/// </summary>
public class ButtonManager : MonoBehaviour
{
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

    public void Restart() {
        LevelManager.instance.RestartLevel();
        Play();
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

    public void BackToSink() {
        LevelManager.instance.StopAllBalls();
        LevelManager.instance.AllBallsToSink();
    }
}

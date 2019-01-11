using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GetComponent<UIManager>().ResetStars();
        Play();
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
        Debug.Log("Vuelvo a cargar el menu");
    }

    public void GoToNextLevel() {
        Debug.Log("Al siguiente niv");
        GetComponent<UIManager>().hideVictoryPopUp();
        GameManager.instance.NextLevel();
        GetComponent<UIManager>().ResetStars();
    }

    public void BackToSink() {
        LevelManager.instance.StopAllBalls();
        LevelManager.instance.AllBallsToSink();
    }
}

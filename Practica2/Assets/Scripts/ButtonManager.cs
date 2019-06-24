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
    UIManager uIManager;
    private void Start()
    {
        uIManager = GetComponent<UIManager>();
    }
    public void Pause()
    {
        uIManager.TogglePausaMenu(true);
        LevelManager.instance.ChangeState(LevelState.PAUSE);
    }

    public void Play() {
        uIManager.TogglePausaMenu(false);
        LevelManager.instance.ChangeState(LevelState.PLAY);
        LevelManager.instance.ActivateTouch();
    }

    public void Restart() {
        uIManager.HideDefeatPopUp();
        uIManager.Restart();
        LevelManager.instance.RestartLevel();
        Play();
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }

    public void GoToNextLevel() {
        Debug.Log("Al siguiente niv");
        uIManager.hideVictoryPopUp();
        GameManager.instance.NextLevel();
        uIManager.ResetStars();
    }

    public void BackToSink() {
        LevelManager.instance.StopAllBalls();
        LevelManager.instance.AllBallsToSink();
    }

    public void UseEarthquacke() {
        GameManager.instance.UsePowerUp(PowerUp.EARTHQUACKE);
        uIManager.UpdatePowerUpButtons();
        Camera.main.GetComponent<Animator>().SetTrigger("Earthquacke");
    }

    public void UseAddBall()
    {
        GameManager.instance.UsePowerUp(PowerUp.EXTRABALL);
        uIManager.UpdatePowerUpButtons();
    }

    public void UseDeleteRow()
    {
        GameManager.instance.UsePowerUp(PowerUp.DELETE);
        uIManager.UpdatePowerUpButtons();
    }

    public void VolumeSlider(float i)
    {
        AudioListener.volume = i;
    }
}

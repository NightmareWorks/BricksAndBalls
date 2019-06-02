using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public RectTransform[] menuBottom= new RectTransform[2];
    public RectTransform menuPausa;
    public StarsUI StarsPuntuacion;
    public Button[] Powerupbuttons;
    public Blink_Effect Warning;

    public Text[] PowerUpText;

    //Window to next level or menu
    public GameObject _victoryPopUp;
    private void Start()
    {
        UpdatePowerUpButtons();
    }
    public void UpdatePowerUpButtons() {
        uint[] PowerUp= GameManager.instance.GetPowerUp();
        for(int i = 0; i < PowerUp.Length; i++) {
            if (PowerUp[i] <= 0)
                Powerupbuttons[i].interactable = false;
            else
                Powerupbuttons[i].interactable = true;
            PowerUpText[i].text = "x" + PowerUp[i].ToString();
        }
    }
    public void activateMenuOnThrow() {
        menuBottom[0].gameObject.SetActive(false);
        menuBottom[1].gameObject.SetActive(true);
    }

    public void activateMenuWaiting() {
        menuBottom[0].gameObject.SetActive(true);
        menuBottom[1].gameObject.SetActive(false);
    }


    public void InitPuntuacion(int maxPuntuacion) {
        StarsPuntuacion.Init(maxPuntuacion);
    }

    public void PuntuacionChanged(float Puntuacion) {
        StarsPuntuacion.OnValueChanged(Puntuacion);
    }

    public void TogglePausaMenu()
    {
        menuPausa.gameObject.SetActive(!menuPausa.gameObject.activeSelf);
    }

    //Callback called when level is finished
    public void VictoryPopUp() {
        _victoryPopUp.SetActive(true);
    }

    public void hideVictoryPopUp()
    {
        _victoryPopUp.SetActive(false);
    }
    public void ResetStars() {
        LevelManager.instance.ResetPuntuacion();
        StarsPuntuacion.ResetStar();
    }

    internal void StartWarning()
    {
        Warning.Blink();
    }

    internal void Restart()
    {
        Warning.Init();
    }
}

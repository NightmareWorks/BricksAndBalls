using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public RectTransform[] menuBottom= new RectTransform[2];
    public RectTransform menuPausa;
    public StarsUI StarsPuntuacion;

    //Window to next level or menu
    [SerializeField]
    private GameObject _victoryPopUp;


    public void ToggleBottomMenu()
    {
        menuBottom[0].gameObject.SetActive(!menuBottom[0].gameObject.activeSelf);
        menuBottom[1].gameObject.SetActive(!menuBottom[1].gameObject.activeSelf);
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
}

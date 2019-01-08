using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public RectTransform[] menuBottom= new RectTransform[2];
    public StarsUI StarsPuntuacion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void toggleBottomMenu()
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
}

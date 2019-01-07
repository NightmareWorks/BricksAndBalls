using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public LevelButton botonNivel;

    // Start is called before the first frame update
    void Start()
    {
        //Pregunta si existe archivo de guardado

        //Si lo hay, carga el estado de los niveles, los rubíes y los items

        //Si no lo hay, inicializa el nivel 1 con 0 estrellas, pone 400 rubíes y ningún item
        botonNivel.init(30, true,1);
    }
}

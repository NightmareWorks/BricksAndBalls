using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarsUI : MonoBehaviour
{
    public Image[] stars = new Image[3];
    [SerializeField]
    public Sprite[] activateStar = new Sprite[2];
    // Start is called before the first frame update
    void Start()
    {
        stars[0].sprite = activateStar[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

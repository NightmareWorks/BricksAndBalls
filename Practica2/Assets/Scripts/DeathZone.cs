using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

	// Use this for initialization
	/*void Start () {
		
	}*/
	
	// Update is called once per frame
	/*void Update () {
		
	}*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject thisBall = collision.gameObject;
        if (firstOne) {
            posX = collision.gameObject.transform.position.x;
            posY = collision.gameObject.transform.position.y;
            firstOne = false;
        }
        //Le dice a la bola que se pare en esa posición
        collision.gameObject.GetComponent<Ball>().stop();
        //Ahora se tendría que mover cada bola al x y
        Debug.Log(posX);

    }

    public float posX, posY;
    public bool firstOne = true;
}

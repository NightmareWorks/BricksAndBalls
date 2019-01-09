using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchDetect : MonoBehaviour {

    private BallSpawner bSpawn;
    private LevelManager lvMgr;
    private Camera cam;


    private Vector2 direction;
    private Vector2 origin;
    private Vector2 destiny;
    bool launch = false;

    // Use this for initialization
    /*void Start () {
		
	}*/

    public void Init(BallSpawner bS)
    {
        lvMgr = LevelManager.instance;
        bSpawn = bS;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update () {
        //Looks for touch
#if UNITY_EDITOR
        if (Input.GetMouseButtonUp(0))
        {
            destiny = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //Convert pixel coordinates to world coordinates
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(destiny.x, destiny.y, cam.nearClipPlane));
            destiny.x = point.x; destiny.y = point.y;
            origin = bSpawn.getLaunchPos();

            direction = destiny - origin;
            launch = true;
        }
#elif UNITY_ANDROID 
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            destiny = new Vector2(touch.position.x,touch.position.y);

            //Convert pixel coordinates to world coordinates
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(destiny.x, destiny.y, cam.nearClipPlane));
            destiny.x = point.x; destiny.y = point.y;
            origin = bSpawn.getLaunchPos();

            direction = destiny - origin;
            launch = true;
        }
#endif
        //Normalizes the direction vector and calls the ballSpawner
        if (launch)
        {
            direction = direction.normalized;
            lvMgr.LaunchBalls(direction);
            launch = false;

            //Y desactiva este componente
            gameObject.SetActive(false);
        }
    }
}

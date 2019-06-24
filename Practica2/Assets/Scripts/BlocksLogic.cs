using UnityEngine;
using System.Collections;

public class Logica : MonoBehaviour
{
    public virtual void Initialize(int type) { }
    public virtual void LogicTrigger(GameObject other) {}
    public virtual void LogicCollision(GameObject collision) {}

}

//Base Block
public class Logica1: Logica {
    public override void Initialize(int type)
    {

    }
    public override void LogicCollision(GameObject collision) {
        base.LogicCollision(collision);
    }
    public override void LogicTrigger(GameObject other)
    {
        base.LogicTrigger(other);
    }
}
//Triangles Logic
//It's the same for block 3,4,5,6

public class Logica3 : Logica
{

    public override void Initialize(int type)
    {
        TextMesh mesh= GetComponentInChildren<TextMesh>();
        switch (type) {
            case 3:
                mesh.anchor = TextAnchor.UpperRight;
                break;
            case 4:
                mesh.anchor = TextAnchor.UpperLeft;
                break;
            case 5:
                mesh.anchor = TextAnchor.LowerLeft;
                break;
            case 6:
                mesh.anchor = TextAnchor.LowerRight;
                break;

        }
    
    }
}
//Block that adds a ball once you hit it
// It's the same for block 21, 22, 23
    public class Logica21 : Logica
{
    int numBall;
    public override void Initialize(int type)
    {
        numBall = type % 20;
        try
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
        catch {
            Debug.Log("Falta PolygonCollider del bloque");
        }
    }

    public override void LogicTrigger(GameObject other)
    {
        LevelManager.instance.AddNewBall((uint)numBall);
        LevelManager.instance.GetBoardManager().DeleteTile(gameObject.GetComponent<Block>());
    }
}

/// Block Logic that changes the direction of the 
/// ball that hits it
public class Logica24: Logica {
    public override void LogicCollision(GameObject collision)
    {
        gameObject.GetComponent<Ball>().ChangeDirX();
    }

}
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
        Debug.Log("HOLA HE FUNCIONADO :D");
    }
    public override void LogicTrigger(GameObject other)
    {
        base.LogicTrigger(other);
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
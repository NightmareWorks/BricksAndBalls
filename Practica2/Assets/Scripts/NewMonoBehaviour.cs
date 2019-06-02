using UnityEngine;
using System.Collections;

public class Logica : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void LogicTrigger(GameObject other) {}
    public virtual void LogicCollision(GameObject collision) {}

}
public class Logica1: Logica {
    public override void LogicCollision(GameObject collision) {
        base.LogicCollision(collision);
        Debug.Log("HOLA HE FUNCIONADO :D");
    }
    public override void LogicTrigger(GameObject other)
    {
        base.LogicTrigger(other);
    }
}
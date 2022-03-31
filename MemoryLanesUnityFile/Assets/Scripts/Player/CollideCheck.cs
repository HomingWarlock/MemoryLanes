using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCheck : MonoBehaviour
{
    public Player_movement playerscript;

    void Start()
    {
        playerscript = gameObject.GetComponentInParent(typeof(Player_movement)) as Player_movement;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.transform.name == "CollideWall")
        {
            playerscript.noMove = true;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.transform.name == "CollideWall")
        {
            playerscript.noMove = false;
        }
    }
}

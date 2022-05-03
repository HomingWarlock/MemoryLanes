using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCheck : MonoBehaviour
{
    public Player_Movement player_script;

    void Start()
    {
        player_script = gameObject.GetComponentInParent(typeof(Player_Movement)) as Player_Movement;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.transform.name == "collide_tile")
        {
            player_script.no_move = true;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.transform.name == "collide_tile")
        {
            player_script.no_move = false;
        }
    }
}

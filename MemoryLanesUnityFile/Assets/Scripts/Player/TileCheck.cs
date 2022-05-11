using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCheck : MonoBehaviour
{
    public Player_Movement player_script;

    void Start()
    {
        player_script = GameObject.Find("player").GetComponent<Player_Movement>();
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.transform.name == "player")
        {
            player_script.current_tile = int.Parse(this.transform.name[10].ToString());
        }
    }
}

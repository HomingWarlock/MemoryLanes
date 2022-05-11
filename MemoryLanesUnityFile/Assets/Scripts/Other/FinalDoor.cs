using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Player_Movement player_script;
    public SimonSays simonsays_script;
    public GameObject FinalDoors;

    void Start()
    {
        player_script = GameObject.Find("player").GetComponent<Player_Movement>();
        simonsays_script = GameObject.Find("simonsays_puzzle").GetComponent<SimonSays>();
        FinalDoors = GameObject.Find("FinalDoors");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !player_script.is_moving && !player_script.is_rotating && simonsays_script.paper_collected)
        {
            if (player_script.current_tile == 6 && player_script.transform.eulerAngles.y == 180)
            {
                Destroy(FinalDoors);
                player_script.final_move = true;
                player_script.final_call = true;
            }
        }
    }
}
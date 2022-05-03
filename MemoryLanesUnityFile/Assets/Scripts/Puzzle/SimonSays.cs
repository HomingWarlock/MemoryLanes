using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    public Player_Movement player_script;
    public GameObject main_camera;
    public Transform simonsays_campoint;
    public bool in_puzzle;

    void Start()
    {
        player_script = GameObject.Find("player").GetComponent<Player_Movement>();
        main_camera = GameObject.Find("main_camera");
        main_camera.transform.position = new Vector3(0, 6.5f, -12.5f);
        main_camera.transform.rotation = Quaternion.Euler(-2, 1, 0);
        simonsays_campoint = GameObject.Find("simonsays_campoint").transform;
        in_puzzle = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !player_script.is_moving && !player_script.is_rotating && !in_puzzle)
        {
            if (player_script.current_tile == 1)
            {
                in_puzzle = true;
                main_camera.transform.position = new Vector3(simonsays_campoint.transform.position.x, simonsays_campoint.transform.position.y, simonsays_campoint.transform.position.z);
                main_camera.transform.rotation = Quaternion.Euler(10, -90, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && !player_script.is_moving && !player_script.is_rotating && in_puzzle)
        {
            in_puzzle = false;
            main_camera.transform.position = new Vector3(0, 6.5f, -12.5f);
            main_camera.transform.rotation = Quaternion.Euler(-2, 1, 0);
        }
    }
}

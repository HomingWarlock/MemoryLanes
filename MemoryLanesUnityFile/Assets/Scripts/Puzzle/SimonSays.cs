using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    public Player_Movement player_script;
    public GameObject main_camera;
    public Transform simonsays_campoint;
    public bool in_puzzle;
    public bool player_turn;
    public int[] sequence;
    public int sequence_no;
    public int round_no;
    public int player_button_presses;
    public GameObject[] button_objects;
    public Material button_normal;
    public Material button_flash;
    public bool is_flashing;
    public int button_clicked;
    public GameObject codepaper;
    public bool paper_falling;
    public bool paper_ready;
    public bool paper_collected;

    void Start()
    {
        player_script = GameObject.Find("player").GetComponent<Player_Movement>();
        main_camera = GameObject.Find("main_camera");
        main_camera.transform.position = new Vector3(0, 6.5f, -12.5f);
        main_camera.transform.rotation = Quaternion.Euler(-2, 1, 0);
        simonsays_campoint = GameObject.Find("simonsays_campoint").transform;
        in_puzzle = false;
        player_turn = false;
        sequence = new int[3];

        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = 99;
        }

        sequence_no = 0;

        round_no = 0;
        player_button_presses = 0;
        button_objects = new GameObject[9];

        for (int i = 0; i < button_objects.Length; i++)
        {
            button_objects[i] = GameObject.Find("simonbutton" + i);
        }

        is_flashing = false;
        button_clicked = 99;
        codepaper = GameObject.Find("codepaper");
        codepaper.SetActive(false);
        paper_falling = false;
        paper_ready = false;
        paper_collected = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !player_script.is_moving && !player_script.is_rotating && !in_puzzle && !paper_falling)
        {
            if (player_script.current_tile == 1 && player_script.transform.eulerAngles.y == 0)
            {
                in_puzzle = true;
                player_turn = false;
                is_flashing = false;
                button_clicked = 99;
                sequence_no = 0;
                round_no = 0;
                player_button_presses = 0;
                player_script.puzzle_lock = true;
                main_camera.transform.position = new Vector3(simonsays_campoint.transform.position.x, simonsays_campoint.transform.position.y, simonsays_campoint.transform.position.z);
                main_camera.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && !player_script.is_moving && !player_script.is_rotating && in_puzzle)
        {
            in_puzzle = false;
            player_script.puzzle_lock = false;
            main_camera.transform.position = new Vector3(0, 6.5f, -12.5f);
            main_camera.transform.rotation = Quaternion.Euler(-2, 1, 0);
        }

        if (in_puzzle)
        {
            if (!player_turn)
            {
                if (round_no == 0 && !is_flashing)
                {
                    if (sequence[sequence_no] == 99)
                    {
                        sequence[sequence_no] = Random.Range(0, 8);
                    }

                    button_objects[sequence[sequence_no]].GetComponent<Renderer>().material = button_flash;
                    StartCoroutine(FlashDelay());
                    is_flashing = true;
                }
            }
            else if (player_turn)
            {
                if (round_no == 0)
                {
                    if (button_clicked != 99)
                    {
                        if (button_clicked != sequence[sequence_no])
                        {
                            Debug.Log("Fail");
                        }
                        else if (button_clicked == sequence[sequence_no])
                        {
                            player_turn = false;
                            button_clicked = 99;
                            codepaper.SetActive(true);
                            paper_falling = true;
                            in_puzzle = false;
                        }
                    }
                }
            }
        }

        if (paper_falling && !paper_collected && codepaper.transform.position.y >= 6.4f)
        {
            codepaper.transform.position += new Vector3(0, -1 * Time.deltaTime, 0);
        }
        else
        {
            paper_ready = true;
        }
    }

    public IEnumerator FlashDelay()
    {
        yield return new WaitForSeconds(1);

        if (round_no == 0)
        {
            is_flashing = false;
            player_turn = true;
            button_objects[sequence[sequence_no]].GetComponent<Renderer>().material = button_normal;
        }
        else if (round_no == 1 && sequence_no == 0)
        {
            button_objects[sequence[sequence_no]].GetComponent<Renderer>().material = button_normal;
            is_flashing = false;
            sequence_no += 1;
        }
        else if (round_no == 1 && sequence_no == 1)
        {
            button_objects[sequence[sequence_no]].GetComponent<Renderer>().material = button_normal;
            is_flashing = false;
            player_turn = true;
        }
        else if (round_no == 2 && sequence_no == 0)
        {
            button_objects[sequence[sequence_no]].GetComponent<Renderer>().material = button_normal;
            is_flashing = false;
            sequence_no += 1;
        }
        else if (round_no == 2 && sequence_no == 1)
        {
            button_objects[sequence[sequence_no]].GetComponent<Renderer>().material = button_normal;
            is_flashing = false;
            sequence_no += 1;
        }
        else if (round_no == 2 && sequence_no == 2)
        {
            button_objects[sequence[sequence_no]].GetComponent<Renderer>().material = button_normal;
            is_flashing = false;
            player_turn = true;
        }
    }
}

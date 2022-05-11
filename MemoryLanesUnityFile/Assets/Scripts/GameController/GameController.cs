using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject menu_object;
    public GameObject game_object;
    public GameObject final_screen;

    public bool is_final_screen;
    public bool do_once;

    void Start()
    {
        menu_object.SetActive(true);
        game_object.SetActive(false);
        final_screen.SetActive(false);

        is_final_screen = false;
        do_once = false;
    }

    private void Update()
    {
        if (is_final_screen && !do_once)
        {
            do_once = true;
            menu_object.SetActive(false);
            game_object.SetActive(false);
            final_screen.SetActive(true);
        }
    }

    public void PlayButtonClicked()
    {
        menu_object.SetActive(false);
        game_object.SetActive(true);
        final_screen.SetActive(false);
    }
}

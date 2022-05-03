using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject menu_object;
    public GameObject game_object;

    void Start()
    {
        menu_object.SetActive(true);
        game_object.SetActive(false);
    }

    public void PlayButtonClicked()
    {
        menu_object.SetActive(false);
        game_object.SetActive(true);
    }
}

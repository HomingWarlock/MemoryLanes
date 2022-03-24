using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject menu_test;

    void Start()
    {
        menu_test.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Enter))
        {
            menu_test.SetActive(false);
        }
    }
}

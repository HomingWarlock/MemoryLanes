using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject menuObject;
    public GameObject maingameObjet;

    void Start()
    {
        menuObject.SetActive(true);
        maingameObjet.SetActive(false);
    }

    public void PlayButtonClicked()
    {
        menuObject.SetActive(false);
        maingameObjet.SetActive(true);
    }
}

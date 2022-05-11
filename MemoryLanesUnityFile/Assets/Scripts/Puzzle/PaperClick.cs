using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperClick : MonoBehaviour
{
    public SimonSays simonsays_script;

    void Awake()
    {
        simonsays_script = GameObject.Find("simonsays_puzzle").GetComponent<SimonSays>();
    }

    void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (simonsays_script.paper_ready)
            {
                simonsays_script.paper_collected = true;
                simonsays_script.codepaper.SetActive(false);
            }
        }
    }
}

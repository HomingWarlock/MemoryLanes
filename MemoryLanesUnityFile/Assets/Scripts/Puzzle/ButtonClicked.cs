using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour
{
    public SimonSays simonsays_script;

    void Awake()
    {
        simonsays_script = GetComponentInParent(typeof(SimonSays)) as SimonSays;
    }

    void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (simonsays_script.in_puzzle)
            {
                if (simonsays_script.player_turn)
                {
                    simonsays_script.button_clicked = int.Parse(this.transform.name[11].ToString());
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int forwardBool;
    public int speedFloat;

    private void Awake()
    {
        forwardBool = Animator.StringToHash("Foward");
        speedFloat = Animator.StringToHash("Speed");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidInteract : MonoBehaviour
{
    public bool Flashlight = false;

    void Start()
    {
        Flashlight = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!Flashlight)
            {
                Flashlight = true;
            }
            else
            {
                Flashlight = false;
            }
        }
    }
}

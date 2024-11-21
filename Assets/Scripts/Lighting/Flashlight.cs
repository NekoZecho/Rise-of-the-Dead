using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    InputActionReference moveActionRef;

    private DavidInteract interact;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interact = player.GetComponent<DavidInteract>();
    }

    void Update()
    {
        if (interact.Flashlight)
        {
           gameObject.GetComponent<Light2D>().enabled = true;
        }
        else if (!interact.Flashlight)
        {
            gameObject.GetComponent<Light2D>().enabled = false;
        }
        TheFlashlightThings();
    }

    private void TheFlashlightThings()
    {
        Vector2 mousePos = moveActionRef.action.ReadValue<Vector2>();
        transform.up = mousePos;
    }

}

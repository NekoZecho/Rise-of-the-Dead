using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    GameObject player;

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
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        mousePos = mousePos - transform.position;
        mousePos.Normalize();
        transform.up = mousePos;
    }

}

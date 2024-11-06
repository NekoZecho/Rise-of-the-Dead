using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    GameObject[] theLights;
    [SerializeField]
    GameObject GlobalLight;
    bool swapped = false;
    [SerializeField]
    Color Default;
    [SerializeField]
    float intensityChange = 0.25f;

    void Start()
    {
        List<Color> colors = new List<Color>();

        theLights = GameObject.FindGameObjectsWithTag("ColoredLightsMain");

        for (int i = 0; i < theLights.Length; i++)
        {
            theLights[i].GetComponent<Light2D>().color = Default;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            colorSwap();
        }
    }

    private void colorSwap()
    {
        if (swapped == false)
        {
            for (int i = 0; i < theLights.Length; i++)
            {
                theLights[i].GetComponent<Light2D>().color = Color.white;
                theLights[i].GetComponent<Light2D>().pointLightOuterRadius += 5;
                theLights[i].GetComponent<Light2D>().falloffIntensity -= 0.25f;
                theLights[i].GetComponent<Light2D>().shadowIntensity -= 0.75f;
            }
            GlobalLight.GetComponent<Light2D>().intensity += intensityChange;
            swapped = true;
        }
        else if (swapped == true)  
        {
            for (int i = 0; i < theLights.Length; i++)
            {
                theLights[i].GetComponent<Light2D>().color = Color.red;
                theLights[i].GetComponent<Light2D>().pointLightOuterRadius -= 5;
                theLights[i].GetComponent<Light2D>().falloffIntensity += 0.25f;
                theLights[i].GetComponent<Light2D>().shadowIntensity += 0.75f;
                GlobalLight.GetComponent<Light2D>().intensity -= intensityChange;
            }
            swapped = false;
        }
    }

    public void GameOverColorSwap()
    {
            for (int i = 0; i < theLights.Length; i++)
            {
                theLights[i].GetComponent<Light2D>().color = Color.red;
                theLights[i].GetComponent<Light2D>().pointLightOuterRadius += 5;
                theLights[i].GetComponent<Light2D>().falloffIntensity -= 0.25f;
                theLights[i].GetComponent<Light2D>().shadowIntensity -= 0.75f;
            }
    }
}

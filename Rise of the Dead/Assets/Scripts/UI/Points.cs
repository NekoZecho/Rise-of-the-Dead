using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    [SerializeField]
    int startpoints = 0;
    public int currentPoints;
    [SerializeField]   
    TMP_Text pointsCounter;

    void Start()
    {
        currentPoints = startpoints;
    }

    void Update()
    {
        pointsCounter.text = currentPoints.ToString();
    }
}

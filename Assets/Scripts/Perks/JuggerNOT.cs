using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JuggerNOT : MonoBehaviour
{
    [Header("JuggerNot Settings")]
    [SerializeField]
    int perkCost = 2000;
    [SerializeField]
    int healthIncrease = 3;
    bool hasPerk = false;
    GameObject player;
    GameObject pointHandler;
    bool inRange = false;
    [SerializeField]
    TMP_Text pointcost;

    private DavidHealth health;
    private Points points;

    void Start()
    {
        hasPerk = false;
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<DavidHealth>();
        pointHandler = GameObject.FindGameObjectWithTag("PointHandler");
        points = pointHandler.GetComponent<Points>();
        bool inRange = false;
        pointcost.enabled = false;

    }

    private void Update()
    {
        if (inRange == true)
        {
            JuggerNogBuy();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            pointcost.text = "Perk Cost: " + perkCost.ToString();
            pointcost.enabled = true;
            bool inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            pointcost.enabled = false;
            bool inRange = false;
        }
    }

    public void JuggerNogBuy()
    {
        if (inRange == true && health.interact == true && points.currentPoints >= perkCost && hasPerk == false)
        {
            points.currentPoints -= perkCost;
            health.maxHealth += healthIncrease;
            health.playerHealth += healthIncrease;
            hasPerk = true;
        }
    }
}

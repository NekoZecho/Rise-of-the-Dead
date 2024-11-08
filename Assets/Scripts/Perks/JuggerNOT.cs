using System.Collections;
using System.Collections.Generic;
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

    private DavidHealth health;
    private Points points;

    void Start()
    {
        hasPerk = false;
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<DavidHealth>();
        pointHandler = GameObject.FindGameObjectWithTag("PointHandler");
        points = pointHandler.GetComponent<Points>();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player") && health.interact == true && points.currentPoints >= perkCost && hasPerk == false)
        {
            points.currentPoints -= perkCost;
            health.maxHealth += healthIncrease;
            health.playerHealth += healthIncrease;
            hasPerk = true;
        }
    }

}

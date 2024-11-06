using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    [SerializeField]
    int startingHealth;
    [SerializeField]
    int pointsOnHit = 10;
    [SerializeField]
    int pointsOnDeath = 50;
    int currentHealth;
    int maxHealth;
    GameObject roundHandler;
    GameObject pointHandler;
    [SerializeField]
    int zhealthDebug;

    private Rounds rounds;
    private Points points;

    void Start()
    {
        roundHandler = GameObject.FindGameObjectWithTag("RoundHandler");
        rounds = roundHandler.GetComponent<Rounds>();
        pointHandler = GameObject.FindGameObjectWithTag("PointHandler");
        points = pointHandler.GetComponent<Points>();
        if (rounds.roundNum == 1)
        {
            maxHealth = startingHealth;
        }
        else if (rounds.roundNum > 1)
        {
            maxHealth = Mathf.CeilToInt(startingHealth + (rounds.roundNum - 1) * rounds.getHealthAdd());
        }
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        zhealthDebug = currentHealth;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet")
        {
            currentHealth -= 1;
            if (currentHealth > 0)
            {
                points.currentPoints += pointsOnHit;
                rounds.totalPoints += pointsOnHit;
            }
            else if (currentHealth <= 0)
            {
                Die();
            }
        }

    }

    private void Die()
    {
        rounds.zombiesKilled++;
        rounds.totalZombieKills++;
        rounds.zombiesLeft--;
        points.currentPoints += pointsOnDeath;
        rounds.totalPoints += pointsOnDeath;
        Destroy(gameObject);
    }

}


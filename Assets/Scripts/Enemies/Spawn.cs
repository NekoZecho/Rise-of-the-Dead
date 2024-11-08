using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject zombiePrefab;
    [SerializeField]
    float detectionRadius = 40f;
    int Zombies;
    float spawnTimer;
    GameObject player;
    GameObject roundHandler;

    private Rounds rounds;
    void Start()
    {
        roundHandler = GameObject.FindGameObjectWithTag("RoundHandler");
        rounds = roundHandler.GetComponent<Rounds>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawnTimer = rounds.zombieSpawnCooldown;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        Vector3 distance = player.transform.position - transform.position;

        countZombies();

        if (Zombies < rounds.zombiesLeft && Zombies <= 24 && spawnTimer <= 0 && distance.magnitude <= detectionRadius && rounds.Cooldown <= 0)
        {
            GameObject Zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity);
            spawnTimer = rounds.zombieSpawnCooldown;
        }
    }

    private void countZombies()
    {
        GameObject[] ZombNum = GameObject.FindGameObjectsWithTag("Zombie");
        Zombies = ZombNum.Length;
    }
}

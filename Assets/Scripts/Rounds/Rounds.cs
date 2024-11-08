using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;

public class Rounds : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    float startOnRound = 1;
    float currentRound;
    [SerializeField]
    int zombiesOnRoundOne = 8;
    public float zombieSpawnCooldown = 5f;
    [SerializeField]
    float roundChangeCooldown = 10f;
    [SerializeField]
    TMP_Text roundCount;

    [Header("Round Increase Settings")]
    [SerializeField]
    int healthIncrease = 6;
    [SerializeField]
    float zombieIncreaseMultiplier = 1.25f;
    int currentRoundZombieMax;
    float timer;

    [Header("Sound")]
    [SerializeField]
    AudioSource roundStart;

    [Header("Testing")]
    public float roundNum;
    public int zombiesKilled;
    public int zombiesLeft;
    public int totalZombieKills;
    public int totalPoints = 0;
    public float Cooldown = 10f;
    bool started = false;
    bool coolingDown = true;
    bool playedSound = false;

    void Start()
    {
        totalPoints = 0;
        roundNum = startOnRound;
        roundStart = GetComponent<AudioSource>();
        currentRound = startOnRound;
        Cooldown = roundChangeCooldown;
        roundCount.text = "";
        if (currentRound == 1)
        {
            currentRoundZombieMax = zombiesOnRoundOne;
            zombiesLeft = currentRoundZombieMax;
            roundNum = currentRound;
        }
        if (currentRound > 1)
        {
            currentRoundZombieMax = Mathf.CeilToInt(zombiesOnRoundOne * (currentRound * zombieIncreaseMultiplier));
            zombiesLeft = currentRoundZombieMax;
            roundNum = currentRound;
        }
    }

    void Update()
    {
        Cooldown -= Time.deltaTime;
        if (started == false && Cooldown < (roundChangeCooldown * 0.75))
        {
            firstRoundStart();
        }
        RoundAdjustments();
    }

    private void RoundAdjustments()
    {
        if (zombiesKilled >= currentRoundZombieMax)
        {
            if (coolingDown == false)
            {
                Cooldown = roundChangeCooldown;
                coolingDown = true;
            }
            if (currentRound >= 1 && Cooldown < (roundChangeCooldown * 0.75) && playedSound == false)
            {
                currentRound += 1;
                roundStart.Play();
                roundCount.text = currentRound.ToString();
                roundNum = currentRound;
                playedSound = true;
            }
            if (Cooldown < 0)
            {
                currentRoundZombieMax = Mathf.CeilToInt(zombiesOnRoundOne * (currentRound * zombieIncreaseMultiplier));
                zombiesLeft = currentRoundZombieMax;
                zombiesKilled = 0;
                coolingDown = false;
                playedSound = false;
            }
        }
    }

    public int getHealthAdd()
    {
        return healthIncrease;
    }

    private void firstRoundStart()
    {
        roundStart.Play();
        started = true;
        roundCount.text = startOnRound.ToString();
        coolingDown = false;
    }

}

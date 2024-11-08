using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DavidHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    public int playerHealth = 3;
    public int maxHealth;
    [Header("Regen")]
    [SerializeField]
    float regenSpeed = 2f;
    int regenAmount = 1;
    public float regenTimer;
    public bool interact;
    GameObject GameOverHandler;

    private GameOver gameOver;


    void Start()
    {
        GameOverHandler = GameObject.FindGameObjectWithTag("GameOverHandler");
        gameOver = GameOverHandler.GetComponent<GameOver>();
        maxHealth = playerHealth;
    }

    private void Update()
    {
        regenTimer += Time.deltaTime;
        if (playerHealth < maxHealth && regenTimer > regenSpeed)
        {
            Regen();
        }
        else if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }
        if (Input.GetKey(KeyCode.E))
        {
                interact = true;

        }
        else
        {
            interact = false;
        }
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        regenTimer = 0;
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameOver.Dead = true;
        gameOver.GameOverScreen();
    }

    private void Regen()
    {
        playerHealth += regenAmount;
        regenTimer = 0;
    }
   
}

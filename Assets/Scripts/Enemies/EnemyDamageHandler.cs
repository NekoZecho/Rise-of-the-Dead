using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    public int damageAmount = 1;
    [SerializeField]
    float atkTimer;
    float atkTimerMax;

    private void Start()
    {
        atkTimerMax = atkTimer;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        // Check if the enemy collided with the player
        if (collider.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player
            DavidHealth playerHealth = collider.gameObject.GetComponent<DavidHealth>();

            if (playerHealth != null && atkTimer <= 0)
            {
                // Apply damage to the player
                playerHealth.TakeDamage(damageAmount);
                atkTimer = atkTimerMax;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            DavidHealth playerHealth = collider.gameObject.GetComponent<DavidHealth>();

            if (playerHealth != null && atkTimer <= 0)
            {
                playerHealth.TakeDamage(damageAmount);
                atkTimer = atkTimerMax;
            }
        }
    }


    private void Update()
    {
        atkTimer -= Time.deltaTime;
    }
}

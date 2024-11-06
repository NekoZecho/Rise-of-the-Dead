using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidMovement : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 10f;
    [SerializeField]
    float sprintSpeed = 15f;
    [SerializeField]
    float Stamina = 4f;
    float maxStamina;
    [SerializeField]
    float StaminaRegenT = 2f;
    float StaminaRegen;
    Rigidbody2D rb;
    public bool playerRunning;

    void Start()
    {
        maxStamina = Stamina;
        StaminaRegen = StaminaRegenT;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Stamina > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }
        else
        {
            Walk();
        }
        StaminaRegenerate();
    }

    private void Walk()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(xInput, yInput) * walkSpeed;
        playerRunning = false;
    }

    private void Sprint()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(xInput, yInput) * sprintSpeed;
        Stamina -= Time.deltaTime;
        playerRunning = true;
    }

    private void StaminaRegenerate()
    {
        if (Stamina >= maxStamina)
        {
            Stamina = maxStamina;
            StaminaRegen = 0;
        }
        else if (StaminaRegen >= StaminaRegenT)
        {
            Stamina = maxStamina;
            StaminaRegen = 0;
        }
        else if (Stamina > 0 && Stamina < 4 && playerRunning == false)
        {
            Stamina = maxStamina;
        }
        else if (Stamina <= 0)
        { 
            StaminaRegen += Time.deltaTime;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    [SerializeField]
    InputActionReference moveActionRef;
    bool runToggle = false;

    void Start()
    {
        maxStamina = Stamina;
        StaminaRegen = StaminaRegenT;
        rb = GetComponent<Rigidbody2D>();
        runToggle = false;
    }


    void Update()
    {
        if (Stamina > 0 && runToggle == true)
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
        Vector2 moveDir = moveActionRef.action.ReadValue<Vector2>();
        rb.linearVelocity = moveDir * walkSpeed;
        playerRunning = false;
    }

    private void Sprint()
    {
        Vector2 moveDir = moveActionRef.action.ReadValue<Vector2>();
        rb.linearVelocity = moveDir * sprintSpeed;
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

    public void toggleRun()
    {
        if (runToggle == false)
        {
            runToggle = true;
        }
        else if (runToggle == true)
        {
            runToggle = false;
        }
    }

}

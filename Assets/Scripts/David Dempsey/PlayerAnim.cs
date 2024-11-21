using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    InputActionReference moveActionRef;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 moveDir = moveActionRef.action.ReadValue<Vector2>();
        float xInput = moveDir.x;
        float yInput = moveDir.y;
        GetComponent<Animator>().SetFloat("x", xInput);
        GetComponent <Animator>().SetFloat("y", yInput);
    }
}

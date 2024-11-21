using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DavidShoot : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float bulletSpeed = 10f;
    [SerializeField]
    float bulletDrop = 5.0f;
    [Header("Cooldowns")]
    [SerializeField]
    float fireRate = 0.5f;
    float timer = 0;
    AudioSource shootSound;
    [SerializeField]
    InputActionReference moveActionRef;

    private void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer > fireRate && Time.timeScale != 0 && moveActionRef.action.IsPressed())
        {
            timer = 0;
            Vector2 mousePos = moveActionRef.action.ReadValue<Vector2>();
            //spawn in the bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = mousePos * bulletSpeed;
            bullet.GetComponent<Rigidbody2D>().transform.up = mousePos;
            shootSound.Play();
           Destroy(bullet, bulletDrop);
        }
    }
}

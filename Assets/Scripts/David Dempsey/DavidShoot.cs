using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer > fireRate && Time.timeScale != 0)
        {
            timer = 0;
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            mousePos = mousePos - transform.position;
            mousePos.Normalize();
            //spawn in the bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = mousePos * bulletSpeed;
            bullet.GetComponent<Rigidbody2D>().transform.up = mousePos;
            shootSound.Play();
           Destroy(bullet, bulletDrop);
        }
        else if (Input.GetButton("Fire1") && timer > fireRate && Time.timeScale != 0)
        {
            timer = 0;
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            mousePos = mousePos - transform.position;
            mousePos.Normalize();
            //spawn in the bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = mousePos * bulletSpeed;
            bullet.GetComponent<Rigidbody2D>().transform.up = mousePos;
            shootSound.Play();
            Destroy(bullet, bulletDrop);
        }
    }
}

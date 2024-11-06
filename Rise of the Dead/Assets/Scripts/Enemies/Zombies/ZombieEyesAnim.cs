using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEyesAnim : MonoBehaviour
{
    Animator anim;
    ZombieAI zAI;
    Vector3 dir;

    void Start()
    {
        zAI = GetComponentInParent<ZombieAI>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = zAI.getDir();
        float xDir = dir.x;
        float yDir = dir.y;
        anim.SetFloat("x", xDir);
        anim.SetFloat("y", yDir);
    }
}
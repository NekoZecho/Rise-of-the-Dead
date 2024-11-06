using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ZombieAnims : MonoBehaviour
{
    Transform spTr;
    Animator anim;
    ZombieAI zAI;
    Vector3 dir;
    bool rotate = false;
    Transform sideShadow;
    ShadowCaster2D shS;
    Transform frontShadow;
    ShadowCaster2D shF;

    private const float targetX = 0f;
    private const float firstTargetY = 1f;
    private const float secondTargetY = -1f;
    private const float tolerance = 0.35f;

    void Start()
    {
        zAI = GetComponent<ZombieAI>();
        anim = GetComponent<Animator>();
        spTr = GetComponent<Transform>();
        sideShadow = transform.Find("ShadowCaster Side");
        shS = sideShadow.GetComponent<ShadowCaster2D>();
        frontShadow = transform.Find("ShadowCaster Front");
        shF = frontShadow.GetComponent<ShadowCaster2D>();
    }


    // Update is called once per frame
    void Update()
    {
        
        dir = zAI.getDir();
        float xDir = dir.x;
        float yDir = dir.y;
        Mathf.Abs(xDir);
        if (IsInWalkingUpState() || IsInWalkingDownState())
        {
            verticalMovement();
        }
        else if (xDir < -0.5 && rotate == true)
        {
            transform.rotation = Quaternion.Euler (0, 0, 0);
            rotate = false;
            shS.enabled = true;
            shF.enabled = false;
        }
        else if (xDir > 0.5 && rotate == false)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
            rotate = true;
            shS.enabled = true;
            shF.enabled = false;
        }
        anim.SetFloat("x", xDir);
        anim.SetFloat("y", yDir);

    }
    private bool IsInWalkingUpState()
    {
        float x = anim.GetFloat("x");
        float y = anim.GetFloat("y");  

        return Mathf.Abs(x-targetX) < tolerance && Mathf.Abs(y-firstTargetY) < tolerance;
    }
    private bool IsInWalkingDownState()
    {
        float x = anim.GetFloat("x");
        float y = anim.GetFloat("y");

        return Mathf.Abs(x - targetX) < tolerance && Mathf.Abs(y - secondTargetY) < tolerance;
    }

    private void verticalMovement()
    {
        shS.enabled = false;
        shF.enabled = true;
    }
}

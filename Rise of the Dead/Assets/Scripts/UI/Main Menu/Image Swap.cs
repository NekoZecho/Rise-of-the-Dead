using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwap : MonoBehaviour
{
    [SerializeField]
    Image Background;
    [SerializeField]
    Sprite ImgOne;
    [SerializeField]
    Sprite ImgTwo;
    [SerializeField]
    Sprite ImgThree;
    [SerializeField]
    Sprite ImgFour;
    [SerializeField]
    float swapTimer;
    float swapSpeed;

    private int lastChoice = -1;

    void Start()
    {
        swapSpeed = swapTimer;
    }

    void Update()
    {
         swapTimer -= Time.deltaTime;
        if (swapTimer <= 0)
        {
            int randomChoice;
            do
            {
                randomChoice = Random.Range(0, 3);
            }
            while (randomChoice == lastChoice);

            lastChoice = randomChoice;

                switch (randomChoice)
                {
                    case 0:
                        Background.sprite = ImgOne;
                        break;
                    case 1:
                        Background.sprite = ImgTwo;
                        break;
                    case 2:
                        Background.sprite = ImgThree;
                        break;
                    case 3:
                        Background.sprite = ImgFour;
                        break;
                }
                swapTimer = swapSpeed;
            }
        }
    }

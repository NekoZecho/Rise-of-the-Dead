using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Header("Debug Info")]
    public bool Dead = false;
    [SerializeField]
    float GOScreenTime = 10f;
    [Header("References")]
    GameObject GameOverCanvas;
    GameObject RoundHandler;
    GameObject PointHandler;
    GameObject UI;
    GameObject Lights;
    GameObject DeathCamera;
    GameObject Player;
    Camera PlayerCamera;
    Component Flashlight;
    [SerializeField]
    TMP_Text RoundsSurvived;
    [SerializeField]
    TMP_Text KillsT;
    [SerializeField]
    TMP_Text PointsT;
    [Header("Sound")]
    [SerializeField]
    AudioSource DeadAudio;
    [SerializeField]
    AudioSource AmbientAudio;
    bool GameOverScreenActive = false;
    float GOScreenTimer;

    private Rounds rounds;
    private Points points;
    private LightSwitch lightswitch;


    void Start()
    {
        SetObjects();
        SetComponents();
        GameOverScreenActive = false;
        GameOverCanvas.SetActive(false);
        UI.SetActive(true);
        DeathCamera.SetActive(false);
        Player.SetActive(true);
        PlayerCamera.enabled = true;
        KillsT.text = " ";
        PointsT.text = " ";
        GOScreenTimer = GOScreenTime;
    }

    void Update()
    {
        if (GameOverScreenActive == true)
        {
            GOScreenTimer -= Time.deltaTime;
            Debug.Log(GOScreenTimer);
            if (GOScreenTimer <= 0)
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
    }

    public void GameOverScreen()
    {
        DisableEnableObjects();
        SetText();
        DeadAudio.Play();
        AmbientAudio.Stop();
        GameOverScreenActive = true;
    }

    private void SetObjects()
    {
        GameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas");
        RoundHandler = GameObject.FindGameObjectWithTag("RoundHandler");
        PointHandler = GameObject.FindGameObjectWithTag("PointHandler");
        UI = GameObject.FindGameObjectWithTag("UI");
        Lights = GameObject.FindGameObjectWithTag("LightHandler");
        DeathCamera = GameObject.FindGameObjectWithTag("DeathCamera");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void SetComponents()
    {
        rounds = RoundHandler.GetComponent<Rounds>();
        points = PointHandler.GetComponent<Points>();
        lightswitch = Lights.GetComponent<LightSwitch>();
        PlayerCamera = Player.transform.Find("Main Camera").GetComponent<Camera>();
    }

    private void DisableEnableObjects()
    {
        UI.SetActive(false);
        GameOverCanvas.SetActive(true);
        lightswitch.GameOverColorSwap();
        PlayerCamera.enabled = false;
        Player.SetActive(false);
        DeathCamera.SetActive(true);
    }

    private void SetText()
    {
        if (rounds.roundNum > 1)
        {
            RoundsSurvived.text = "You Survived " + rounds.roundNum + " Rounds";
            KillsT.text = rounds.totalZombieKills.ToString();
            PointsT.text = rounds.totalPoints.ToString();
        }
        else if (rounds.roundNum == 1)
        {
            RoundsSurvived.text = "You Survived " + rounds.roundNum + " Round";
            KillsT.text = rounds.totalZombieKills.ToString();
            PointsT.text = rounds.totalPoints.ToString();
        }
    }

}

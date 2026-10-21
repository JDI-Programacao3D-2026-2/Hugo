using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameStartText;
    public float startTime = 5f;
    public bool StopCountDown;

    //tab

    public GameObject tabPanel;
    public int FragScore = 0;
    public int DeathScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StopCountDown = false;
        startTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //ScorePanel();
        StartCountDown();
    }
    void StartCountDown()
    {
        if(startTime > 0 && !StopCountDown)
        {
            startTime -= Time.deltaTime;
            gameStartText.text = "Game Starts in: " + startTime.ToString("0");
        }
        if(startTime <= 0 && !StopCountDown)
        {
            gameStartText.text = "Game Started!";
            Invoke("ClearCountdown",1f);
        }
    }
    void ClearCountdown()
    {
        gameStartText.text = "";
        StopCountDown = true;
        startTime = 5;
    }
}

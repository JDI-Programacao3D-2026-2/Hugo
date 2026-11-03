using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public float startTime = 5f;
    public bool StopCountDown;

    //tab
    public GameObject tabPanel;
    public int FragScore = 0;
    public int DeathScore;
    public TextMeshProUGUI fragText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI playerNameText;
    public static int ChoosenCharacterIndex = 0;// 0 = Noob, 1 = Vigilante, 2 = swordMaster
    public static CharacterStats ActiveStats;
    public static Transform ActiveChar;

    public static ScoreUI ActiveScoreUI;
    public static PointUI ActiveZoneUI;
    
    /*
    void Start()
    {
        StopCountDown = false;
        startTime = 2;
    }
    */

    // Update is called once per frame
    void Update()
    {
        ScorePanel();
        //StartCountDown();
    }
    /*
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
    */
    void ScorePanel()
    {
        if (ActiveScoreUI == null) return;
        if (Keyboard.current[Key.Tab].wasPressedThisFrame)
        {
            ActiveScoreUI.tabPanel.SetActive(!ActiveScoreUI.tabPanel.activeSelf);
        }
        if(Keyboard.current[Key.Tab].wasReleasedThisFrame)
        {
            ActiveScoreUI.tabPanel.SetActive(false);
        }
    }
    public void UpdateFragScore(int frag)
    {
        FragScore += frag;
        if (ActiveScoreUI != null)
        {
            ActiveScoreUI.fragText.text = FragScore.ToString();
        }
    }
    public void UpdateDeathScore(int death)
    {
        DeathScore += death;
        if (ActiveScoreUI != null)
        {
            ActiveScoreUI.deathText.text = DeathScore.ToString();
        }
    }
    public void PlayerLists(string playerName)
    {
        if (ActiveScoreUI != null)
        {
            ActiveScoreUI.playerNameText.text = playerName;
        }
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PointManag : MonoBehaviour
{
    private int playerZones = 0;
    public int enemyZones = 0;
    private bool gameOver = false;
    private string sceneName;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void ZoneCaptured(bool byPlayer)
    {
        if (gameOver) return;

        if (byPlayer) playerZones++;
        else enemyZones++;

        PointUI ui = GameManager.ActiveZoneUI;

        if(sceneName == "Tutorial")
        {
            if (playerZones >= 1)
            {
                gameOver = true;
                if (ui != null)
                {
                    ui.messageText.text = "VITÓRIA!";
                    Invoke("BackToMenu",5f);
                }
            }
            else if (enemyZones >= 1)
            {
                gameOver = true;
                if (ui != null)
                {
                    ui.messageText.text = "DERROTA!";
                    Invoke("BackToMenu",5f);
                }
                
            }
        }

        if (playerZones >= 2)
        {
            gameOver = true;
            if (ui != null)
            {
                ui.messageText.text = "VITÓRIA!";
                Invoke("BackToMenu",5f);
            }
        }
        else if (enemyZones >= 2)
        {
            gameOver = true;
            if (ui != null)
            {
                ui.messageText.text = "DERROTA!";
                Invoke("BackToMenu",5f);
            }
            
        }
        else
        {
            if (ui != null)
            {
                if(sceneName == "Tutorial") return;
                
                ui.messageText.text = byPlayer ? "Você capturou uma zona!" : "Inimigos capturaram uma zona!";
                CancelInvoke("ClearCapture");
                Invoke("ClearCapture", 3f);
            }
        }
    }
    void ClearCapture()
    {
        PointUI ui = GameManager.ActiveZoneUI;
        if (ui != null) ui.messageText.text = "";
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

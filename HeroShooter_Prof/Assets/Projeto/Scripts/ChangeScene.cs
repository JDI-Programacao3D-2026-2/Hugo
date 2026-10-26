using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void CharSeleciton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharSelection");
    }
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}

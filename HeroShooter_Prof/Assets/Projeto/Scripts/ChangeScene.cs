using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CharSeleciton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharSelection");
    }
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    public void Tutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
    }
}

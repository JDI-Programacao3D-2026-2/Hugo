using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CharSeleciton()
    {
        SceneManager.LoadScene("CharSelection");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Exit()
    {
        Application.Quit();
    }
}

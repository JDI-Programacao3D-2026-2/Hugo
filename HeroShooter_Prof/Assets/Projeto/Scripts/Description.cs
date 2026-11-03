using UnityEngine;
using UnityEngine.SceneManagement;

public class Description : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    public void NoobMaster()
    {
        GameManager.ChoosenCharacterIndex = 0;
        SceneManager.LoadScene("Game");
        //descriptionText.text = "NoobMaster: \n - HP: 100 \n - Press Left Mouse Button: Shoot with your Assault Rifle dealing 20 damage per shot"+
                                //"\n - Press 1: Restore 50 Health, 15s CD \n - Press 2: Create a shield that blocks 50 damage for 5s, 20s CD";
    }
    public void Vigilante()
    {
        GameManager.ChoosenCharacterIndex = 1;
        SceneManager.LoadScene("Game");
        //descriptionText.text = "Vigilante: \n - HP: 120 \n - Press Left Mouse Button: Fire your pistol at enemies dealing 25 damage per shot"+
                                //"\n -Press 1: Throw a camera attaching on structures, Press 1 to watch camera, X to destroy, 20s CD after destroy \n"+ 
                                //"Press 2 : Reveal Enemies Position on minimap, 20s CD";
    }
    public void SwordPro()
    {
        GameManager.ChoosenCharacterIndex = 2;
        SceneManager.LoadScene("Game");
        //descriptionText.text = "SwordPro: \n - HP: 150 \n - Press Left Mouse Button: Swing your sword near enemies dealing 35 damage per hit"+
                                //"\n -Hold Right Mouse Button: Block incoming attacks, 10s CD Full Charge  \n"+
                                //"- Press 1: Increase your movement speed by 50% for 6s, 11s CD";
    }
}

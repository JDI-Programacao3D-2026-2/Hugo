using TMPro;
using UnityEngine;

public class Description : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Start()
    {
        descriptionText.text = "";
    }
    public void NoobMasterDescription()
    {
        GameManager.ChoosenCharacterIndex = 0;
        descriptionText.text = "NoobMaster: \n - Base Health: 100 \n - Press Left Mouse Button: Shoot with your Assault Rifle dealing 20 damage per shot"+
                                "\n - Press 1: Instant Restore 50 Health, 15 seconds cooldown \n - Press 2: Create a shield that blocks 50 damage for 5 seconds, 20 seconds cooldown";
    }
    public void VigilanteDescription()
    {
        GameManager.ChoosenCharacterIndex = 1;
        descriptionText.text = "Vigilante: \n - Base Health: 120 \n - Press Left Mouse Button: Fire your pistol at enemies dealing 25 damage per shot"+
                                "\n -Press 1: Throw a camera attaching on structures, Press 1 to watch camera \n"+ 
                                "Press 2 : Reveal Enemies Position on minimap, 30 seconds cooldown";
    }
    public void SwordProDescription()
    {
        GameManager.ChoosenCharacterIndex = 2;
        descriptionText.text = "SwordPro: \n - Base Health: 150 \n - Press Left Mouse Button: Swing your sword near enemies dealing 35 damage per hit"+
                                "\n -Hold Right Mouse Button: Block incoming attacks, 10 seconds cooldown  \n"+
                                "- Press Shift: Increase your movement speed by 50% for 5 seconds, 15 seconds cooldown";
    }
}

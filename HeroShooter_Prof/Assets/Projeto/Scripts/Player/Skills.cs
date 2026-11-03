using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Skills : MonoBehaviour
{
    private float cd_1Noob = 15f;
    private float cd_2Noob = 20f;
    public Image[] skill_Image;
    private PlayerHealth playerHealth;
    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }


    void Update()
    {        
        SkillsNoobMaster();
    }   

    void ActivateSkill1NoobMaster()
    {
        playerHealth.RestoreHealth(50);
    }
    void ActivateSkill2NoobMaster()
    {
        playerHealth.AddShield(50f, 5f);
    }
    void SkillsNoobMaster()
    {
        if (Keyboard.current[Key.Digit1].wasPressedThisFrame && skill_Image[0].fillAmount >= 1f)
        {            
            skill_Image[0].fillAmount = 0f;
            ActivateSkill1NoobMaster();
        }

        if (skill_Image[0].fillAmount < 1f)
        {
            skill_Image[0].fillAmount += Time.deltaTime / cd_1Noob;
        }
        if (Keyboard.current[Key.Digit2].wasPressedThisFrame && skill_Image[1].fillAmount >= 1f)
        {            
            skill_Image[1].fillAmount = 0f;
            ActivateSkill2NoobMaster();
        }
        if (skill_Image[1].fillAmount < 1f)
        {
            skill_Image[1].fillAmount += Time.deltaTime / cd_2Noob;
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Skills : MonoBehaviour
{
    private float cd_1Noob = 15f;
    private float cd_2Noob = 20f;
    private float cd_1Vigi = 1;
    private float cd_2Vigi = 30;
    public Transform firePoint;
    public GameObject a;

    public Image[] skill_Image;
    private PlayerHealth playerHealth;
    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }
    void Start()
    {
        
    }
    void ChangeCharSkills()
    {
        switch (GameManager.ChoosenCharacterIndex)
        {
            case 0:
                SkillsNoobMaster();
                break;
            case 1:
                SkillsVigilante();
                break;
            case 2:
                SkillsSwordMaster();
                break;
        }
    }

    void Update()
    {        
        ChangeCharSkills();
    }   

    void ActivateSkill1NoobMaster()
    {
        playerHealth.RestoreHealth(50);
    }
    void ActivateSkill2NoobMaster()
    {
        //playerHealth.AddShield(50);
    }
    void ActivateSkill1Vigilante()
    {
        
    }
    void ActivateSkill2Vigilante()
    {
        
    }
    void ActivateSkill1SwordMaster()
    {
        
    }
    void ActivateSkill2SwordMaster()
    {
        
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
    void SkillsVigilante()
    {
        if (Keyboard.current[Key.Digit1].wasPressedThisFrame && skill_Image[0].fillAmount >= 1f)
        {            
            skill_Image[0].fillAmount = 0f;
            ActivateSkill1Vigilante();
        }

        if (skill_Image[0].fillAmount < 1f)
        {
            skill_Image[0].fillAmount += Time.deltaTime / cd_1Vigi;
        }
        if (Keyboard.current[Key.Digit2].wasPressedThisFrame && skill_Image[1].fillAmount >= 1f)
        {            
            skill_Image[1].fillAmount = 0f;
            ActivateSkill2Vigilante();
        }
        if (skill_Image[1].fillAmount < 1f)
        {
            skill_Image[1].fillAmount += Time.deltaTime / cd_2Vigi;
        }
    }
    void SkillsSwordMaster()
    {
        
    }
}

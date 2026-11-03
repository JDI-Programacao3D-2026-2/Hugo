using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkillsSwordMaster : MonoBehaviour
{
    public Image[] skill_Image;
    private float BlocktimeActive = 5.5f;
    private float BlocktimeRecharge = 10f;
    private float cd = 13f;
    public float boostDuration = 7f;
    private float speedBoostEnd = 0f;
    private bool boosting = false;

    public PlayerHealth playerHealth;
    public PlayerMove playerMovement;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMove>();

    }
    void Update()
    {        
        SkillSwordMaster();
    }
    void ActivateSkill2Vigilante()
    {
        playerMovement.speed = 13f;
        boosting = true;
        speedBoostEnd = Time.time + boostDuration;
    }   

    void SkillSwordMaster()
    {
        if (Mouse.current.rightButton.isPressed && skill_Image[0].fillAmount > 0f)
        {            
            skill_Image[0].fillAmount -= Time.deltaTime / BlocktimeActive;
            playerHealth.isBlocking = true;
        }
        else
        {
            playerHealth.isBlocking = false;
            skill_Image[0].fillAmount += Time.deltaTime / BlocktimeRecharge;
        }
        if (Keyboard.current[Key.Digit1].wasPressedThisFrame && skill_Image[1].fillAmount >= 1f)
        {
            skill_Image[1].fillAmount = 0f;
            ActivateSkill2Vigilante();
        }
        if (boosting && Time.time >= speedBoostEnd)
        {
            playerMovement.speed = 5f;
            boosting = false;
        }
        if (skill_Image[1].fillAmount < 1f)
        {
            skill_Image[1].fillAmount += Time.deltaTime / cd;
        }
    }
}

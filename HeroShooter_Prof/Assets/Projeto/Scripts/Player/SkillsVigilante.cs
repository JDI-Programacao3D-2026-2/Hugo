using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkillsVigilante : MonoBehaviour
{
private float cd_1Vigilante = 15f;
    private float cd_2Vigilante = 20f;
    public Image[] skill_Image;


    [Header("Cam")]
    public GameObject camPrefab;  
    public Transform shoulderPoint;        
    public float throwForce = 20f;

    public static bool isWatching = false;

    private SetCam currentCam;
    private bool watching = false;

    public float revealDuration = 8f;


    void Update()
    {   
        SkillsVigi();
    }   

    void ActivateSkill1Vigilante()
    {
        Transform cam = Camera.main.transform;
        Vector3 pos = shoulderPoint.position + cam.forward * 0.5f;

        GameObject obj = Instantiate(camPrefab, pos, cam.rotation);
        currentCam = obj.GetComponent<SetCam>();
        obj.GetComponent<Rigidbody>().linearVelocity = cam.forward * throwForce;
    }
    void ActivateSkill2Vigilante()
    {
        Minimap[] all = FindObjectsByType<Minimap>();
        foreach (Minimap m in all)
        {
            m.Reveal(revealDuration);
        }
    }
    void SkillsVigi()
    {
        if (Keyboard.current[Key.Digit1].wasPressedThisFrame)
        {
            if (currentCam == null)
            {
                if (skill_Image[0].fillAmount >= 1f)
                {
                    ActivateSkill1Vigilante();
                }
            }
            else if (currentCam.stuck)
            {
                ToggleView();
            }
        }

        if (Keyboard.current[Key.X].wasPressedThisFrame && currentCam != null)
        {
            DestroyCam();
        }

        if (currentCam == null && skill_Image[0].fillAmount < 1f)
        {
            skill_Image[0].fillAmount += Time.deltaTime / cd_1Vigilante;
        }

        if (Keyboard.current[Key.Digit2].wasPressedThisFrame && skill_Image[1].fillAmount >= 1f)
        {
            skill_Image[1].fillAmount = 0f;
            ActivateSkill2Vigilante();
        }
        if (skill_Image[1].fillAmount < 1f)
        {
            skill_Image[1].fillAmount += Time.deltaTime / cd_2Vigilante;
        }
    }
    void ToggleView()
    {
        watching = !watching;
        isWatching = watching;
        currentCam.SetViewing(watching);
    }
    void DestroyCam()
    {
        if (isWatching) ToggleView();
        Destroy(currentCam.gameObject);
        currentCam = null;
        skill_Image[0].fillAmount = 0f;
    }
    void OnDisable()
    {
        if (isWatching && currentCam != null) currentCam.SetViewing(false);
        isWatching = false;
    }
}

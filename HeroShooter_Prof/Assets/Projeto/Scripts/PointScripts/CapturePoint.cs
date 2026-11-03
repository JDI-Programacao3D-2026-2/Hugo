using UnityEngine;
using UnityEngine.InputSystem;
public class CapturePoint : MonoBehaviour
{
    public PointManag manager;
    private float captureTime = 20f;

    private int playersInside = 0;
    private int enemiesInside = 0;
    private float progress = 0f;
    private bool captured = false;
    private bool isPlayerCapturing = false;
    private bool capturing = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerHealth>() != null) playersInside++;
        if (other.GetComponentInParent<EnemyHealth>() != null) enemiesInside++;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<PlayerHealth>() != null) playersInside--;
        if (other.GetComponentInParent<EnemyHealth>() != null) enemiesInside--;
        if (playersInside == 0) HideBar();
    }

    void Update()
    {
    if (captured) return;

    if(playersInside > 0 && enemiesInside == 0 || enemiesInside > 0 && playersInside == 0)
        {
            capturing = true;
        }
    

    if (capturing)
        {
            progress += Time.deltaTime;
            isPlayerCapturing = playersInside > 0;
        }
    PointUI ui = GameManager.ActiveZoneUI;

    if (ui != null && (playersInside > 0 || enemiesInside > 0))
    {
        ui.barRoot.SetActive(true);
        ui.bar.fillAmount = progress / captureTime;
    }
    else
    {
        HideBar();
    }

    if (progress >= captureTime)
    {
        captured = true;
        HideBar();
        manager.ZoneCaptured(isPlayerCapturing);
    }
    }

    void HideBar()
    {
        PointUI ui = GameManager.ActiveZoneUI;
        if (ui != null) ui.barRoot.SetActive(false);
    }
}

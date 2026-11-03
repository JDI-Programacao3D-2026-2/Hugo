using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject minimapMarker;
    public float revealTime = 3f;
    private float revealUntil = 0f;

    public void Reveal(float duration)
    {
        if (minimapMarker == null)
        {
            return;
        }
        revealUntil = Mathf.Max(revealUntil, Time.time + duration);
        minimapMarker.SetActive(true);
    }

    void Update()
    {
        if (minimapMarker != null && minimapMarker.activeSelf && Time.time >= revealUntil)
        {
            minimapMarker.SetActive(false);
        }
        
    }
}

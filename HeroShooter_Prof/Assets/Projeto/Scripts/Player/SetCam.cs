using UnityEngine;

public class SetCam : MonoBehaviour
{
    public Camera cam;
    public bool stuck = false;
    private Rigidbody rb;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam.enabled = false;            
    }

    void OnCollisionEnter(Collision collision)
    {
        if (stuck) return;
        stuck = true;

        rb.isKinematic = true;
        transform.rotation = Quaternion.LookRotation(collision.contacts[0].normal);
    }

    public void SetViewing(bool on)
    {
        cam.enabled = on;
    }

}

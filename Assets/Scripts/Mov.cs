using UnityEngine;
using UnityEngine.InputSystem;
public class Mov : MonoBehaviour
{
    public Rigidbody rb;
    private float vel = 5f;

    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;

        if (Keyboard.current[Key.W].isPressed)
        {
            direction += transform.forward;
        }
        else if (Keyboard.current[Key.A].isPressed)
        {
            direction += Vector3.left;
        }
        else if (Keyboard.current[Key.D].isPressed)
        {
            direction += transform.right;
        }
        else if (Keyboard.current[Key.S].isPressed)
        {
            direction += Vector3.back;
        }

        direction = Vector3.ClampMagnitude(direction, 1f);

        rb.linearVelocity = new Vector3(direction.x * vel, direction.y , direction.z * vel);
        
    }

}

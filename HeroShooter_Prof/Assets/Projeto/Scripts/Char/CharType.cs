using UnityEngine;

public class CharType : MonoBehaviour
{
    private PlayerHealth playerHealth;
    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        switch (GameManager.ChoosenCharacterIndex)
        {
            case 0:
                playerHealth.Health(100);
                break;
            case 1:
                playerHealth.Health(120);
                break;
            case 2:
                playerHealth.Health(150);
                break;
        }
    }
}

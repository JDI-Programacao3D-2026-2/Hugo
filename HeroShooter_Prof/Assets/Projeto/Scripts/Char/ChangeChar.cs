using UnityEngine;

public class ChangeChar : MonoBehaviour
{
    public GameObject[] characters;
    public Transform[] shoulderPoints;
    public MouseOrbit cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Choose(GameManager.ChoosenCharacterIndex);
    }

    void Choose(int index)
    {
        if(index < 0 || index >= characters.Length)
        {
            index = 0;
        }
        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == index);
        }
        cam.player = shoulderPoints[index];
        GameManager.ActiveChar = characters[index].transform;
        
    }
}

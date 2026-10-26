using UnityEngine;

public class PersonagemRPG : MonoBehaviour
{
public string nome = "Arthas";
public int vida = 50; 
public float velocidade = 7.5f;
 public bool estaVivo = true;
public const int VIDA_MAXIMA = 100;

    void Start()
    {
        nome = "Arthas";
        vida = 100;
        velocidade = 7.5f;
        estaVivo = true;
    }

}

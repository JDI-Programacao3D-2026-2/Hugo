using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public string[] steps =
    {
        "Use W, A, S, D para andar",
        "Clique com o botão esquerdo do mouse para atirar",
        "Use 1 e 2 para as habilidades",
        "Capture as zonas para vencer!"
    };

    private int current = 0;
    private float nextStepTime = 0f;

    void Start()
    {
        Show();
    }

    void Update()
    {
        if (current >= steps.Length) return;

        bool done = false;

        if (current == 0 && Keyboard.current[Key.W].wasPressedThisFrame) done = true;
        if (current == 1 && Mouse.current.leftButton.wasPressedThisFrame) done = true;
        if (current == 2 && (Keyboard.current[Key.Digit1].wasPressedThisFrame ||
                             Keyboard.current[Key.Digit2].wasPressedThisFrame)) done = true;
        if (current == 3 && Time.time >= nextStepTime) done = true;

        if (done)
        {
            current++;
            nextStepTime = Time.time + 5f;
            Show();
        }
    }

    void Show()
    {
        if (current < steps.Length) tutorialText.text = steps[current];
        else tutorialText.text = "";
    }
}

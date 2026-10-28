using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Header("Configurações de Visão")]
    public float visionRange = 10f;
    [Tooltip("Campo de visão total (ex: 160 graus)")]
    public float fieldOfView = 160f;
    public float sweepSpeed = 3f;
    public LayerMask targetLayer;
    public LayerMask obstacleLayer;

    private float currentAngleOffset;

    void Update()
    {
        float maxHalfAngle = fieldOfView / 2f;
        currentAngleOffset = Mathf.Sin(Time.time * sweepSpeed) * maxHalfAngle;

        // 2. Definimos duas direções espelhadas para os 2 Raycasts trabalharem juntos
        Vector3 leftRayDirection = Quaternion.Euler(0, currentAngleOffset, 0) * transform.forward;
        Vector3 rightRayDirection = Quaternion.Euler(0, -currentAngleOffset, 0) * transform.forward;

        // 3. Dispara os dois sensores móveis
        CheckRaycastVision(leftRayDirection);
        CheckRaycastVision(rightRayDirection);

        // Desenha os raios no editor da Unity para você visualizar o escaneamento
        Debug.DrawRay(transform.position, leftRayDirection * visionRange, Color.cyan);
        Debug.DrawRay(transform.position, rightRayDirection * visionRange, Color.cyan);
    }

    private void CheckRaycastVision(Vector3 direction)
    {
        RaycastHit hit;

        // Dispara o raio checando tanto alvos quanto paredes/obstáculos
        if (Physics.Raycast(transform.position, direction, out hit, visionRange, targetLayer | obstacleLayer))
        {
            // Se o que o raio atingiu está na camada do jogador/alvo
            if (((1 << hit.collider.gameObject.layer) & targetLayer) != 0)
            {
                Debug.Log($"Jogador detectado pelo sensor móvel! Ponto de impacto: {hit.point}");
                Debug.DrawLine(transform.position, hit.point, Color.red);
                // Aqui você pode acionar o estado de alerta do inimigo
            }
        }
    }
}
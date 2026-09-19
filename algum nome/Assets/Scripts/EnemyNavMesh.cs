using UnityEngine;
using UnityEngine.AI;
public class EnemyNavMesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        MoverInimigo();
    }
    void MoverInimigo()
    {
        if(player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}

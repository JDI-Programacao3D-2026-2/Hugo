using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyNavMesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public Transform[] capturePoint;

    public LayerMask layerMask;

    public float losePlayerDistance = 15f;
    [Header("Melee Settings")]
    public bool isMelee = false;
    public float attackRange = 1.5f;
    private float damage = 40f;
    private float attackCooldown = 1f;
    private float nextAttackTime = 0f;

    public PointManag pointManager;
    public float timeAtPoint = 25f;    
    private Transform currentTarget; 
    private float changeTargetTime = 15f;


    public float patrolDuration = 20f;
    private float patrolEndTime = 0f;


    public enum EnemyState{
        WayPatrol, Pursuit, CapturePoint
    }
    public EnemyState currentState = EnemyState.WayPatrol;

    void Start()
    {
        patrolEndTime = Time.time + patrolDuration;
    }

    void Update(){
    player = GameManager.ActiveChar;
    FiniteStateMachine();
    }
    public void ChangeState(EnemyState newState)
    {
        currentState = newState;
        currentTarget = null; 

        if (newState == EnemyState.WayPatrol)
            patrolEndTime = Time.time + patrolDuration;
    }

 void FiniteStateMachine(){
        switch (currentState){
            case EnemyState.Pursuit:
                Pursuit();
                break;

            case EnemyState.WayPatrol:
                WayPatrol();
                break;
            case EnemyState.CapturePoint:
                CapturePoint();
                break;
            default:
                break;
        }
    }

 void Pursuit(){
        agent.stoppingDistance = isMelee ? attackRange - 0.5f : 8f;
        agent.SetDestination(player.position);
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (isMelee && distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            PlayerHealth health = player.GetComponent<PlayerHealth>();
            if (health != null) health.TakeDamage(damage);
            nextAttackTime = Time.time + attackCooldown;
        }
        
        if (distanceToPlayer > losePlayerDistance)
        {
            ChangeState(EnemyState.WayPatrol);
        }
    }
    void WayPatrol()
    {
        if (Time.time >= patrolEndTime)
        {
            ChangeState(EnemyState.CapturePoint);
            return;
        }
        agent.stoppingDistance = 0f;
        if (waypoints.Length != 0 && !agent.pathPending &&
        agent.remainingDistance < 0.5f)
        {                        
            int randomIndex = Random.Range(0, waypoints.Length);
            agent.SetDestination(waypoints[randomIndex].position);
        }
        //SearchPlayer();
    }
    void SearchPlayer()
    {
        /*
        if(Physics.Raycast(transform.position, transform.forward, 
        out RaycastHit hit, 20f, layerMask)){
            ChangeState(EnemyState.Pursuit);  
                 CallBackup();         
        }
        */
    }
    public void CallBackup()
    {
       EnemyNavMesh[] todosInimigos = FindObjectsByType<EnemyNavMesh>();
        foreach (EnemyNavMesh aliado in todosInimigos)
        {  
            float distancia = Vector3.Distance(transform.position, 
            aliado.transform.position);
            if (distancia < 10f)
            {
                aliado.ChangeState(EnemyState.Pursuit);
            }
        }
    }
    void CapturePoint()
    {
        agent.stoppingDistance = 0f;

        if (currentTarget == null || Time.time >= changeTargetTime)
        {
            currentTarget = capturePoint[Random.Range(0, capturePoint.Length)];
            changeTargetTime = Time.time + timeAtPoint;
            agent.SetDestination(currentTarget.position);
        }

        if (pointManager.enemyZones == 1)
        {
            ChangeState(EnemyState.WayPatrol);
        }
    }
}

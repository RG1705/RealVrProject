using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreddyAI : MonoBehaviour
{
    public FieldOfView fov;
    public bool isChasing = false;
    public NavMeshAgent enemy;
    public Transform Player;
    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    public float patrolSpeed = 112.0f;
    private float switchTimer = 0.0f;
    private bool switchingPoints = false;
    public float chaseSpeed = 15.0f;


    void Start()
    {
        SetNextPatrolDestination();
    }

    void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else if (!enemy.pathPending && enemy.remainingDistance < 2.0f)
        {
            SetNextPatrolDestination();
        }
        else if (enemy.hasPath && switchingPoints)
        {
            if (enemy.remainingDistance < 2.0f)
            {
                SetNextPatrolDestination();
                switchingPoints = false;
            }
        }
        else
        {
            switchTimer -= Time.deltaTime;
            if (switchTimer <= 0.0f)
            {
                if (Random.value < 0.25f)
                {
                    int randomIndex = Random.Range(0, patrolPoints.Length);
                    enemy.SetDestination(patrolPoints[randomIndex].position);
                    enemy.speed = patrolSpeed;

                    GameObject pointObject = GameObject.Find(patrolPoints[randomIndex].name);
                    Debug.Log("Going to patrol point " + pointObject.name);

                    switchingPoints = true;
                    Debug.Log("Switching patrol points");
                }
                switchTimer = Random.Range(2.0f, 5.0f);
            }
        }

        // Can See?
        if (fov.canSeePlayer)
        {
            // Can see = Chase
            SetChasing(true);
        }
        else
        {
            // Can't see = Patrol
            SetChasing(false);
        }
    }

    void SetNextPatrolDestination()
    {
        int randomIndex = Random.Range(0, patrolPoints.Length);
        enemy.SetDestination(patrolPoints[randomIndex].position);
        enemy.speed = patrolSpeed;

        GameObject pointObject = GameObject.Find(patrolPoints[randomIndex].name);
        Debug.Log("Going to patrol point " + pointObject.name);
    }

    void ChasePlayer()
    {
        enemy.speed = chaseSpeed;
        enemy.SetDestination(Player.position);
    }

    public void SetChasing(bool chasing)
    {
        isChasing = chasing;
    }
}
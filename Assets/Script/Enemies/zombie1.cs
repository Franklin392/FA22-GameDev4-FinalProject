using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie1 : MonoBehaviour
{

    public Animator animator;

    // AIÐÐ¶¯
    NavMeshAgent thisNavMeshAgent;
    public enemyState currentState;

    //distance ¼ì²â
    public float dist;//distance
    public float MaxDistance;
    public Transform Player;

    //Health
    public float Health;
    public float injury;
    //die time
    public float DieTime;
    public enum enemyState
    {
        ChaseNow,Attack,Die,LoseHealth
    }
    void Start()
    {
        thisNavMeshAgent = GetComponent<NavMeshAgent>();

        //¶¯»­
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Player.position, transform.position);


        switch (currentState)
        {
            case enemyState.ChaseNow:
                ChaseNow();
                break;
            case enemyState.Attack:
                Attack();
                break;
            case enemyState.Die:
                Die();
                break;
            case enemyState.LoseHealth:
                LoseHealth();
                break;
        }

        if (dist >= MaxDistance)
        {
            currentState = enemyState.ChaseNow;


        }

        if (dist <= MaxDistance)
        {
            //thisNavMeshAgent.isStopped = true;
            Debug.Log(" Zombie stop");
            //ANIM
            currentState = enemyState.Attack;
        }

        if(Health <= 0)
        {
            currentState = enemyState.Die;
        }
    }
    public void ChaseNow()
    {
        GameObject[] Player = GameObject.FindGameObjectsWithTag("Player");
        GameObject targetBObject = Player[0];
        Debug.Log(" chasing player now ");
        thisNavMeshAgent.SetDestination(targetBObject.transform.position);

        animator.SetTrigger("Walk");
        //ANIM
        //if (dist <= MaxDistance)
        //{
        //    //thisNavMeshAgent.isStopped = true;
        //    Debug.Log(" Zombie stop");
        //    //ANIM
        //    Attack();
        //}

    }
    public void Attack()
    {
        animator.SetTrigger("Attack");

        if (dist >= 1)
        {
            currentState = enemyState.ChaseNow;


        }
    }
    public void Die()
    {
        Debug.Log("Z1 DIE");
        animator.SetTrigger("Die");
        DieTime -=1 * Time.deltaTime;

        thisNavMeshAgent.isStopped = true;

        if (DieTime <= 0)
        {
            Destroy(gameObject);
        }
        
        
    }
    public void LoseHealth()
    {
        Health -= injury;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            currentState = enemyState.LoseHealth;
            animator.SetTrigger("GetHit");
        }
    }

    private void OnTriggerExit(Collider other)
    {



    }
}

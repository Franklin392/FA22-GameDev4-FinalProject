using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlySoldier : MonoBehaviour
{
    public Animator animator;

    // AIÐÐ¶¯
    NavMeshAgent thisNavMeshAgent;
    public friendlyState currentState;

    //distance ¼ì²â
    public float dist;//distance
    public float MaxDistance;
    public Transform Player;

    //Health
    public float Health;
    public float injury;
    //die time
    public float DieTime;
    public enum friendlyState
    {
        ChaseNow, Attack, Die, LoseHealth
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
            case friendlyState.ChaseNow:
                ChaseNow();
                break;
            case friendlyState.Attack:
                Attack();
                break;
            case friendlyState.Die:
                Die();
                break;
            case friendlyState.LoseHealth:
                LoseHealth();
                break;
        }

        if (Health <= 0)
        {
            currentState = friendlyState.Die;
        }
    }
    public void ChaseNow()
    {
        GameObject[] Player = GameObject.FindGameObjectsWithTag("Player");
        GameObject targetBObject = Player[0];
        Debug.Log(" chasing player now ");
        thisNavMeshAgent.SetDestination(targetBObject.transform.position);

        animator.SetTrigger("Walk");
        if (dist <= MaxDistance)
        {
            thisNavMeshAgent.isStopped = true;
            Debug.Log(" Girl no more chase BOY ");
           
        }
        else
        {
            thisNavMeshAgent.isStopped = false;
        }

    }
    public void Attack()
    {
        animator.SetTrigger("Attack");

       
    }

    public void LoseHealth()
    {
        Health -= injury;
    }

    public void Die()
    {
        Debug.Log("Z1 DIE");
        animator.SetTrigger("Die");
        DieTime -= 1 * Time.deltaTime;

        thisNavMeshAgent.isStopped = true;

        if (DieTime <= 0)
        {
            Destroy(gameObject);
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAttack")
        {
            currentState = friendlyState.LoseHealth;
        }
    }

    private void OnTriggerExit(Collider other)
    {



    }
}

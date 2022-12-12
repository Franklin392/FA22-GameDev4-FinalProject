using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenZombie : MonoBehaviour
{
    public Animator animator;

    public Collider bodyCollider;
    public Collider headCollider;
    // AI�ж�
    NavMeshAgent thisNavMeshAgent;
    public enemyState currentState;

    //distance ���
    public float dist;//distance
    public float MaxDistance;
    public float ChaseDistance;
    public Transform Player;

    //Health
    public float Health;
    public float injury, headinjury;
    //die time
    public float DieTime;
    //Bloods
    public GameObject Blood;
    public GameObject HeadBlood;
    public Transform BodyBlood;
    public Transform HeadBloodyHell;
    //Score
    public int coins;
    public ScoreManager SM;
    public enum enemyState
    {
        ChaseNow, Attack, Die, LoseBodyHealth, LoseHeadHealth, Stop
    }
    private void Awake()
    {
        //�һ���ϵͳ
        SM = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        //find player
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        thisNavMeshAgent = GetComponent<NavMeshAgent>();

        //����
        animator = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void FixedUpdate()
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

            case enemyState.LoseBodyHealth:
                LoseBodyHealth();
                break;
            case enemyState.LoseHeadHealth:
                LoseHeadHealth();
                break;

            case enemyState.Stop:
                Stop();
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

        if (dist >= MaxDistance && dist > ChaseDistance)
        {
            currentState = enemyState.Stop;
        }

        if (Health <= 0)
        {
            currentState = enemyState.Die;
        }
    }
    public void ChaseNow()
    {
        thisNavMeshAgent.isStopped = false;

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
        DieTime -= 1 * Time.deltaTime;

        thisNavMeshAgent.isStopped = true;

        if (DieTime <= 0)
        {
            coins += 20;
            SM.AddCoinPoint3();
            Destroy(gameObject);
        }


    }
    public void LoseBodyHealth()
    {
        Health -= injury;
        //��Ѫ��
        Instantiate(Blood, BodyBlood.position, Quaternion.identity);
    }
    public void LoseHeadHealth()
    {
        Health -= headinjury;
        Instantiate(HeadBlood, HeadBloodyHell.position, Quaternion.identity);
    }

    public void Stop()
    {
        thisNavMeshAgent.isStopped = true;
        animator.SetTrigger("Stop");
    }


    public void TakeDamageNow(Collider hitCollider)
    {
        if (hitCollider == headCollider)
        {
            currentState = enemyState.LoseHeadHealth;
            Debug.Log("HEADSHOT WOW");

        }

        if (hitCollider == bodyCollider)
        {
            currentState = enemyState.LoseBodyHealth;
            Debug.Log("bodySHOT WOW");

        }

        //currentState = enemyState.LoseHealth;
        //animator.SetTrigger("GetHit");
    }
}

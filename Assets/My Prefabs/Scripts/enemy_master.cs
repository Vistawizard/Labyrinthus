using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class enemy_master : MonoBehaviour
{
    public float minDist = 1;
    public float movementSpeed;

    public int attack_damage = 1;
    
    public bool isAngered;
    public bool isDead;

    public GameObject enemy;
    public GameObject closest;
    
    //private float health = 20;

    public Transform PlayerPosition;

    public NavMeshAgent navComponent;
    public float delay;
    [SerializeField] private Animator PowAttack;
    

    

    // Start is called before the first frame update
    void Start()
    {
        navComponent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navComponent = GetComponent<NavMeshAgent>();
        closest = SearchForTarget();
        FollowTarget(closest);
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, closest.transform.position) <= minDist)
        {
            StartCoroutine(Attack());
        }
        else
            PowAttack.SetBool("powAttack", false);
            
    }

    IEnumerator Attack()
    {
        PowAttack.SetBool("powAttack", true);
        yield return new WaitForSeconds(delay);
        closest.GetComponent<PlayerController>().TakeDamage(attack_damage);
    }

    public GameObject SearchForTarget()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject _closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                _closest = go;
                distance = curDistance;
            }
        }
        return _closest;
    }

    public void FollowTarget(GameObject target)
    {
        navComponent.speed = movementSpeed;

        navComponent.SetDestination(target.transform.position);
    }

    
}

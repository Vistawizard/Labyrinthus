using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class enemy_master : MonoBehaviour
{
    public float minDist = 2;
    public float movementSpeed;

    public int attack_damage = 3;
    
    public bool isAngered;
    public bool isDead;

    public GameObject enemy;
    public GameObject closest;
    
    //private float health = 20;

    public Transform PlayerPosition;

    public NavMeshAgent navComponent;

    

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
        //if (Vector3.Distance(transform.position, closest.transform.position) <= minDist)
            // this is where the player will take damage
            
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

    // public void TakeDamage(float damage)
    // {
    //     Debug.Log("took damage");
    //     
    //     health -= damage;
    //     
    //     if (health <= 0)
    //     {
    //         Destroy(this);
    //     }
    // }
    //
    // [PunRPC]
    // void RPC_TakeDamage(float damage)
    // {
    //     Debug.Log("took damage");
    //     health -= damage;
    //     
    //     if (health <= 0)
    //     {
    //         Destroy(this);
    //     }
    // }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_master : MonoBehaviour
{
    public float minDist = 2;
    public float movementSpeed;

    public bool isAngered;
    public bool isDead;

    public GameObject enemy;
    public GameObject closest;


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
        if (Vector3.Distance(transform.position, closest.transform.position) <= minDist)
            // this is where the player will take damage
            Debug.Log("AI attack");
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

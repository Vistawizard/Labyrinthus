using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_master : MonoBehaviour
{
    public GameObject Player;
    public float Distance;
    public float radius = 10f;

    public bool isAngered;

    public NavMeshAgent _agent;

    // LastKnownPos = 0f, 0f, 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Distance = Vector3.Distance(Player.transform.position, this.transform.position);

        if(Distance <= radius)
        {
            isAngered = true;
        }
        else
        {
            isAngered = false;
        }
        if (isAngered)
        {
            _agent.isStopped = false;

            _agent.SetDestination(Player.transform.position);
        }
        if(!isAngered)
        {
            _agent.isStopped = true;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

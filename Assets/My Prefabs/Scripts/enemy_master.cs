using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public class enemy_master : MonoBehaviour
{
    public float Distance;
    public float radius = 10f;
    public float movementSpeed;

    public bool isAngered;
    public bool isDead;

    public NavMeshAgent _agent;

    public GameObject Target;

    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        //player = GameObject.Find("Player(Clone)");
        // _agent = GetComponent<NavMeshAgent>();
        // Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Target == null)
            {
                SearchForTarget();
            }
            else
            {
                FollowTarget();
            }

        }

    }

    void SearchForTarget()
    {
        
        Vector3 center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Collider[] hitColliders = Physics.OverlapSphere(center, 100);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].transform.tag == "Player(Clone)")
            {
                Target = player;
                Debug.Log(Target);
                //Debug.Log("Found player");
            }
            i++;
        }
    }

    void FollowTarget()
    {
        Vector3 targetPosition = Target.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);

        float distance = Vector3.Distance(Target.transform.position, this.transform.position);
        if (distance > 30)
        {
            transform.Translate(Vector3.forward * movementSpeed);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

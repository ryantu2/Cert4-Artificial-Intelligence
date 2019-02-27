using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{

    //enemy needs to have a target to go to (this variable)
    public Transform target;

    //reference to the NavMeshAgent co
    private NavMeshAgent agent;


    // Use this for initialization
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //update destination of navmesh
        agent.SetDestination(target.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    #region Variables
    public Transform waypointParent; // transform = position + rotation + scale (3 x vetor3 = 3 x 3 floats)
    public float moveSpeed = 2f;
    public float stoppingDistance = 1f; // how far to a way point it will be to switch to a new way point

    public Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;

    #endregion


    // Use this for initialization
    void Start()
    {
        // get children of waypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        // get referenece to this objects navMeshAgent component
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol ()
    {
        // get the current way point
        Transform point = waypoints[currentIndex];
        // get distance to way point
        float distance = Vector3.Distance(this.transform.position, point.position);

        // if close to waypoint
        if (distance < stoppingDistance)
        {
            // switch to waypoint
            currentIndex++;

            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
            
            
        }

        // translate enemy to waypoint - AKA moving smoothly from one point to another at a speed
        // built in function MoveTowards
        //current
        //target
        //speed(delta)
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed*Time.deltaTime);

        // new translate
        agent.SetDestination(point.position);

    }
}

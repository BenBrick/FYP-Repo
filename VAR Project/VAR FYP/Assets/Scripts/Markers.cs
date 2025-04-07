using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Profiling;

public class Markers : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Rigidbody rb;
    Animator animator;
    private bool Tackled = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (gameObject.tag == "M1")
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal3");
        }

        if (gameObject.tag == "M2")
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal4");
        }
        
        StartAgent();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Animation();
        if (agent.remainingDistance < 0.5f)
        {
            StopAgent();
            animator.SetBool("isRunning", false);
        }
    }

    public void Animation()
    {
        PointInTime point = GetComponent<Rewind>().pointsInTime[0];

        if (transform.position != goalLocations[0].transform.position)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void StartAgent()
    {
        agent.SetDestination(goalLocations[0].transform.position);
    }

    public void ResumeAgent()
    {
        agent.isStopped = false;
    }

    public void StopAgent()
    {
        agent.isStopped = true;
    }
}

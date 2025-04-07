using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Profiling;

public class Mover : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Rigidbody rb;
    Animator animator;
    public bool Tackled = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        StartAgent();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Animation();
        if (agent.remainingDistance < 0.7f)
        {
            StopAgent();
            animator.SetBool("isRunning", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TacklePlayer"))
        {
            Tackled = true;
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

        if (Tackled)
        {
            animator.SetBool("isTackled", true);
            StopAgent();
        }

        if (!Tackled)
        {
            ResumeAgent();
            animator.SetBool("isTackled", false);
        }

        if (gameObject.tag == "TacklePlayer")
        {
            if (agent.remainingDistance >= 1.2f)
            {
                animator.SetBool("isTackling", true);
            }
            else
            {
                StopAgent();
                gameObject.transform.position = rb.transform.position;
                animator.SetBool("isTackling", false);
            }
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

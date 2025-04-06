using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Rigidbody rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
        if (gameObject.CompareTag("Player1"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal1");
        }
        
        else if (gameObject.CompareTag("Player5"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal2");
        }
        
        else if (gameObject.CompareTag("Player3"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal5");
        }
        
        else if (gameObject.CompareTag("Player11"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal4");
        }
        
        else if (gameObject.CompareTag("Player6"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal3");
        }
        
        else if (gameObject.CompareTag("Player7"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal3(2)");
        }
        
        else if (gameObject.CompareTag("Player8"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal6");
        }
        
        else if (gameObject.CompareTag("Player4"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal7");
        }
        
        else if (gameObject.CompareTag("Player10(2)"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal8");
        }
        
        else if (gameObject.CompareTag("Player5(2)"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("goal9");
        }
        
        StartAgent();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Animation();
        if (agent.remainingDistance <= 0.2f)
        {
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
        
    }

    public void StartAgent()
    {
        agent.SetDestination(goalLocations[0].transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        StartAgent();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            StopAgent();
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

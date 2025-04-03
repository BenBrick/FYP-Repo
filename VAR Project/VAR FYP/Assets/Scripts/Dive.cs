using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Profiling;

public class Dive : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Rigidbody rb;
    Animator animator;
    public bool dived = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Animation();
    }
    public void Animation()
    {
        if (agent.remainingDistance <= 1.5f && dived == false)
        {
            StartCoroutine(DiveAnim());
        }
    }

    private IEnumerator DiveAnim()
    {
        agent.isStopped = true;
        rb.velocity = Vector3.zero;
        
        yield return new WaitForSecondsRealtime(0.3f);
        
        animator.SetBool("isRunning", false);
        animator.SetBool("Dive", true);
        
        yield return new WaitForSeconds(1.5f);
        
        dived = true;
        animator.SetBool("Dive", false);
    }
}

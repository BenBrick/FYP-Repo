using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Profiling;

public class Kick : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Rigidbody rb;
    Animator animator;
    private float force = 1.0f;
    public bool Kicked = false;

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
        if (agent.remainingDistance < 0.2f && Kicked == false)
        {
            StartCoroutine(KickAnim());
        }
    }

    private IEnumerator KickAnim()
    {
        
        yield return new WaitForSeconds(0.8f);
        
        animator.SetBool("isRunning", false);
        animator.SetBool("Kicked", true);
        Kicked = true;
        
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("Kicked", false);
    }
}

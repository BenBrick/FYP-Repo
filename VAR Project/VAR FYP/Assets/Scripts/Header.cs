using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Profiling;

public class Header : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Rigidbody rb;
    Animator animator;
    private float force = 1.0f;
    public bool Headed = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        goalLocations = GameObject.FindGameObjectsWithTag("goal2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Animation();
        if (agent.remainingDistance < 0.5f)
        {
            animator.SetBool("isRunning", false);
        }
    }
    public void Animation()
    {
        PointInTime point = GetComponent<Rewind>().pointsInTime[0];

        if (transform.position != point.position)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (agent.remainingDistance <= 1.0f && Headed == false)
        {
            StartCoroutine(HeaderAnim());
        }
    }

    private IEnumerator HeaderAnim()
    {
        
        animator.SetBool("isRunning", false);
        animator.SetBool("Heading", true);
        Headed = true;

        yield return new WaitForSecondsRealtime(0.22f);
        agent.isStopped = true;
        rb.velocity = Vector3.zero;
        Vector3 up = transform.up * (force * 65.0f);
        rb.AddForce(up, ForceMode.Impulse);
        
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Heading", false);
    }
}

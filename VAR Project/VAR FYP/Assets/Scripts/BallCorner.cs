using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BallCorner : MonoBehaviour
{
    private float force = 1.00f;
    private float speed = 2.00f;
    private float minSpeed = 0.2f;
    private float slow = 0.99f;
    GameObject[] goalLocations;
    private Rigidbody rb;
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = this.GetComponent<NavMeshAgent>();
        goalLocations = GameObject.FindGameObjectsWithTag("HeaderPlayer");
    }
    
    public void StartAgent()
    {
        agent.SetDestination(goalLocations[0].transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            agent.isStopped = true;
            agent.enabled = false;
            Rigidbody playerRB = collision.gameObject.GetComponent<Rigidbody>();
            
            if (playerRB != null)
            {
                Vector3 dir = (transform.position - collision.transform.position).normalized;

                Vector3 momentum = Vector3.Project(rb.velocity * rb.mass, dir);
                rb.velocity -= momentum;
                
                Vector3 forward = dir * (force * 7f);
                Vector3 right = transform.forward * (force * 9.4f);
                Vector3 up = transform.up * (force * 3.9f);

                rb.AddForce(forward - right + up, ForceMode.Impulse);
                StartCoroutine(navMeshAgent());
            }
        }

        if (collision.gameObject.CompareTag("HeaderPlayer"))
        {
            agent.isStopped = true;
            agent.enabled = false;
            Rigidbody playerRB2 = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRB2 != null)
            {
                Vector3 dir = (transform.position - collision.transform.position).normalized;
                Vector3 momentum = Vector3.Project(rb.velocity * rb.mass, dir);
                rb.velocity -= momentum;
                
                //Vector3 forward = dir * (force * 4f);
                Vector3 right = transform.forward * (force * 10f);
                Vector3 down = transform.up * (force * 1.84f);
                rb.AddForce(right - down, ForceMode.Impulse);
            }
        }
    }

    private IEnumerator navMeshAgent()
    {
        yield return new WaitForSeconds(0.63f);
        agent.enabled = true;
        agent.isStopped = false;
        rb.velocity = Vector3.zero;
        StartAgent();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity;
        }
        else if (rb.velocity.magnitude > minSpeed)
        {
            rb.velocity *= slow;
        }
        else if (rb.velocity.magnitude <= 0.03f)
        {
            rb.velocity = Vector3.zero;
        }
    }
}

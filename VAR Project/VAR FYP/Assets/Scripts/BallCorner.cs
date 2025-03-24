using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallCorner : MonoBehaviour
{
    private float force = 1.00f;
    private float speed = 2.00f;
    private float minSpeed = 0.2f;
    private float slow = 0.99f;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRB = collision.gameObject.GetComponent<Rigidbody>();
            
            if (playerRB != null)
            {
                Vector3 dir = (transform.position - collision.transform.position).normalized;

                Vector3 momentum = Vector3.Project(rb.velocity * rb.mass, dir);
                rb.velocity -= momentum;
                
                Vector3 forward = dir * (force * 6f);
                Vector3 right = transform.forward * (force * 9.4f);
                Vector3 up = transform.up * (force * 1.8259f);

                rb.AddForce(forward - right + up, ForceMode.Impulse);
                
            }
        }

        if (collision.gameObject.CompareTag("HeaderPlayer"))
        {
            Rigidbody playerRB2 = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRB2 != null)
            {
                Vector3 dir = (transform.position - collision.transform.position).normalized;
                Vector3 momentum = Vector3.Project(rb.velocity * rb.mass, dir);
                rb.velocity -= momentum;
                
                Vector3 forward = dir * (force * 4f);
                Vector3 right = transform.forward * (force * 10f);
                Vector3 down = transform.up * (force * 1.84f);
                rb.AddForce(forward - right - down, ForceMode.Impulse);
            }
        }
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

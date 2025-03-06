using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float force = 1.00f;
    public float speed = 2.00f;
    public float minSpeed = 0.2f;
    public float slow = 0.99f;
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
                Debug.Log($"Before collision - Velocity: {rb.velocity}");

                Vector3 momentum = Vector3.Project(rb.velocity * rb.mass, dir);
                rb.velocity -= momentum;

                rb.AddForce(dir * (force * 5f), ForceMode.Impulse);

                Debug.Log($"After collision - Velocity: {rb.velocity}");
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

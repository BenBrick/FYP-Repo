using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float force = 1f;
    public float speed = 2f;
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
                rb.AddForce(dir * (force * playerRB.mass), ForceMode.Impulse);
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

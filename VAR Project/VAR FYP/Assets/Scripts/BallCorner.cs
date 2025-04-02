using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;

public class BallCorner : MonoBehaviour
{
    private float force = 1.00f;
    private float speed = 2.00f;
    private float minSpeed = 0.2f;
    private float slow = 0.99f;
    GameObject[] goalLocations;
    private Rigidbody rb;
    public SplineAnimate spline2;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        goalLocations = GameObject.FindGameObjectsWithTag("HeaderPlayer");
        StartSpline();
    }

    public void StartSpline()
    {
        spline2.Restart(true);
        
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

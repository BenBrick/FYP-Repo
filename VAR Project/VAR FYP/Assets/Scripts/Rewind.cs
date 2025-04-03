using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class Rewind : MonoBehaviour
{
    // Reference Video: https://www.youtube.com/watch?v=eqlHpPzS22U

    private bool isRewinding = false;
    private bool isPaused = false;
    private bool isFastForward = false;
    private bool isRunning = false;
    private float recordTime = 10f;
    public List<PointInTime> pointsInTime;
    List<PointInTime> previousPIT;
    List<PointInTime> originalPIT;
    Rigidbody rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        originalPIT = new List<PointInTime>();
        previousPIT = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        originalPIT.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ToggleRewind();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ToggleFast();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private void FixedUpdate()
    {
        /*if (isRewinding)
        {
            Rewinder();
        }*/

        Recorder();

        /*if (isFastForward)
        {
            FastForwarder();
        }
        else
        {
            Player();
        }

        if (isPaused)
        {
            Pauser();
        }
        else
        {
            Player();
        }*/
    }

    private void Restart()
    {
        transform.position = originalPIT[0].position;
        transform.rotation = originalPIT[0].rotation;
        if (gameObject.tag == "HeaderPlayer")
        {
            gameObject.GetComponent<Header>().Headed = false;
            gameObject.GetComponent<Header>().Animation();
        }
        if (gameObject.tag == "Player2")
        {
            gameObject.GetComponent<Dive>().dived = false;
            gameObject.GetComponent<Dive>().Animation();
        }
    }

    private void Recorder()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
            previousPIT.RemoveAt(previousPIT.Count - 1);
        }
        
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        previousPIT.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    /*private void Rewinder()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
    }

    private void FastForwarder()
    {
        if (previousPIT.Count > 0)
        {
            PointInTime pointInTime1 = previousPIT[previousPIT.Count -1];

            transform.position = pointInTime1.position;
            transform.rotation = pointInTime1.rotation;

            previousPIT.RemoveAt(previousPIT.Count -1);
        }
    }

    private void Pauser()
    {
        if (GetComponent<Mover>() != null)
        {
            GetComponent<Mover>().StopAgent();
        }

        if (GetComponent<Markers>() != null)
        {
            GetComponent<Markers>().StopAgent();
        }
    }

    private void Player()
    {
        if (GetComponent<Mover>() != null)
        {
            GetComponent<Mover>().ResumeAgent();
        }

        if (GetComponent<Markers>() != null)
        {
            GetComponent<Markers>().ResumeAgent();
        }
        
    }*/

    private void TogglePause()
    {
        isPaused = !isPaused;
        rb.isKinematic = true;
    }

    private void ToggleFast()
    {
        isFastForward = !isFastForward;
        rb.isKinematic = true;
    }

    private void ToggleRewind()
    {
        isRewinding = !isRewinding;
        rb.isKinematic = true;
    }
}

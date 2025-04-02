using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BallRewind : MonoBehaviour
{
    // Reference Video: https://www.youtube.com/watch?v=eqlHpPzS22U

    private bool isRewinding = false;
    private bool isPaused = false;
    private bool isFastForward = false;
    public float recordTime = 5f;
    List<PointInTime> pointsInTime;
    List<PointInTime> previousPIT;
    List<PointInTime> originalPIT;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        previousPIT = new List<PointInTime>();
        originalPIT = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
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
        if (isRewinding)
        {
            Rewinder();
        }
        else
        {
            Recorder();
        }

        if (isFastForward)
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
        }
    }
    
    public void Restart()
        {
            transform.position = originalPIT[0].position;
            transform.rotation = originalPIT[0].rotation;
            GetComponent<BallCorner>().StartSpline();
        }

    public void Recorder()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
            previousPIT.RemoveAt(previousPIT.Count - 1);
        }
        
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        previousPIT.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    public void Rewinder()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
    }

    public void FastForwarder()
    {
        if (previousPIT.Count > 0)
        {
            PointInTime pointInTime1 = previousPIT[previousPIT.Count -1];

            transform.position = pointInTime1.position;
            transform.rotation = pointInTime1.rotation;

            previousPIT.RemoveAt(previousPIT.Count -1);
        }
    }

    public void Pauser()
    {
        
    }

    public void Player()
    {
        
        
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        rb.isKinematic = true;
    }

    public void ToggleFast()
    {
        isFastForward = !isFastForward;
        rb.isKinematic = true;
    }

    public void ToggleRewind()
    {
        isRewinding = !isRewinding;
        rb.isKinematic = true;
    }
}

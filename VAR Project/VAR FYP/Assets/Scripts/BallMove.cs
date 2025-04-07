using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class BallMove : MonoBehaviour
{
    public SplineAnimate spline;
    // Start is called before the first frame update
    void Start()
    {
        StartSpline();
    }

    public void StartSpline()
    {
        StartCoroutine(moveBall());
    }

    private IEnumerator moveBall()
    {
        yield return new WaitForSeconds(0.5f);
        spline.Restart(true);
    }

}

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    [SerializeField]
    public CinemachineVirtualCamera[] VARCams;
    private int CurrentCam = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetCam(CurrentCam);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SwitchCam(1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            SwitchCam(-1);
        }
    }

    void SwitchCam(int Dir)
    {
        VARCams[CurrentCam].Priority = 0;

        CurrentCam += Dir;
        if (CurrentCam <= 0)
        {
            CurrentCam = VARCams.Length - 1;
        }
        else if ((CurrentCam >= VARCams.Length))
        {
            CurrentCam = 0;
        }

        SetCam(CurrentCam);
    }

    void SetCam(int index)
    {
        for (int i = 0; i < VARCams.Length; i++)
        {
            VARCams[i].Priority = (i == index) ? 10 : 0;
        }
    }
}

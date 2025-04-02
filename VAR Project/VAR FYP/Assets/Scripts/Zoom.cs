using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    private CinemachineBrain brain;
    
    // Start is called before the first frame update
    void Start()
    {
        brain = Camera.main.GetComponent<CinemachineBrain>();
    }
    
    private void Zoomer()
    {
        ICinemachineCamera activeCam = brain.ActiveVirtualCamera;

        if (activeCam is CinemachineVirtualCamera vcam)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
            
                vcam.m_Lens.FieldOfView -= 2.0f;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                vcam.m_Lens.FieldOfView += 2.0f;
            }
        }
        
        else if (activeCam is CinemachineFreeLook freeLookCam)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
            
                freeLookCam.m_Lens.FieldOfView -= 2.0f;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                freeLookCam.m_Lens.FieldOfView += 2.0f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Zoomer();
    }
}

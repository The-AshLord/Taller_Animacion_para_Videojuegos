using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] referencePoints;
    [SerializeField] private CinemachineVirtualCamera[] virtualCams;
    
    [SerializeField] private CinemachineVirtualCamera cam0;
    [SerializeField] private CinemachineVirtualCamera cam1;
    [SerializeField] private CinemachineVirtualCamera cam2;
    [SerializeField] private CinemachineVirtualCamera startCam;
    [SerializeField] private CinemachineVirtualCamera currentCam;
    

    void Start()
    {
        currentCam = startCam;

        for (int i = 0; i < virtualCams.Length; i++)
        {
            if (virtualCams[i] == currentCam)
            {
                virtualCams[i].Priority = 20;
            }
            else
            {
                virtualCams[i].Priority = 10;
            }
        }
    }

    public void SwitchCams(CinemachineVirtualCamera newCam)
    {
        currentCam = newCam;
        currentCam.Priority = 20;
        for (int i = 0; i < virtualCams.Length; i++)
        {
            if (virtualCams[i] != currentCam)
            {
                virtualCams[i].Priority = 10;
            }
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCams(cam2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        If(collision.gameObject.CompareTag("re"))
    }
}

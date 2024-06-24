using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private CinemachineFreeLook VirtualCamera;

    [SerializeField]
    private CinemachineFreeLook.Orbit[] OrbitList = new CinemachineFreeLook.Orbit[3];

    [SerializeField]
    [Tooltip("Speed of sroll zoom.")]
    private float mouseScrollScale = 0.01f;

    [SerializeField]
    private float ZoomMultiplier = 1f;
    private float ZoomMultiplierDesired = 1f;
    private float ZoomMultiplierStart = 1f;
    
    void Start()
    {
       FreeLookValues(VirtualCamera);
    }

    // Update is called once per frame
    void Update()
    {
        MouseScrollZoomChange(mouseScrollScale);
        FreeLookZoomChange(VirtualCamera, ZoomMultiplier);
        SmoothTransition();
    }

    private void FreeLookValues(CinemachineFreeLook freeLook)
    {
        VirtualCamera = GetComponent<CinemachineFreeLook>();

        for (int i = 0; i < VirtualCamera.m_Orbits.Length; i++)
        {
            OrbitList[i].m_Height = VirtualCamera.m_Orbits[i].m_Height;
            OrbitList[i].m_Radius = VirtualCamera.m_Orbits[i].m_Radius;
        }
    }

    private void FreeLookZoomChange(CinemachineFreeLook freeLook, float zoomMultiplier)
    {
        for (int i = 0; i < freeLook.m_Orbits.Length; i++) 
        {
            freeLook.m_Orbits[i].m_Height = OrbitList[i].m_Height * zoomMultiplier;
            freeLook.m_Orbits[i].m_Radius = OrbitList[i].m_Radius * zoomMultiplier;
        }
    }

    private void MouseScrollZoomChange(float scale)
    {
        float mouseDelta = ZoomMultiplier + -Input.mouseScrollDelta.y * scale;
        if (mouseDelta < 0.6)
        {
            ZoomMultiplierDesired = 0.6f;
        }
        else if (mouseDelta > 3)
        {
            ZoomMultiplierDesired = 3f;
        }
        else ZoomMultiplierDesired = mouseDelta; 
    }

    private void SmoothTransition()
    {
        ZoomMultiplier = Mathf.SmoothStep(ZoomMultiplierStart, ZoomMultiplierDesired, 1f);
    }
}
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
   [SerializeField] private float zoomSpeed = 10f;
   [SerializeField] private float minZoom = 5f;
   [SerializeField] private float maxZoom = 15f;

    private CinemachineVirtualCamera virtualCam;
    private bool _isvirtualCamNotNull;

    void Start()
    {
        _isvirtualCamNotNull = virtualCam != null;
        virtualCam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (_isvirtualCamNotNull)
        {
            virtualCam.m_Lens.FieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            virtualCam.m_Lens.FieldOfView = Mathf.Clamp(virtualCam.m_Lens.FieldOfView, minZoom, maxZoom);
        }
    }
    
}
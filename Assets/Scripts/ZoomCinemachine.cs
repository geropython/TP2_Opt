using System;
using Cinemachine;
using UnityEngine;

public class ZoomCinemachine : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float maxCameraDistance;
    [SerializeField] float minCameraDistance;
    float cameraDistance;
    [SerializeField] float sensitivity = 10f;
    CinemachineComponentBase componentBase;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Follow3RdZoom();
    }

    private void FramingZoom()
    {
        if (componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
            maxCameraDistance = (componentBase as CinemachineFramingTransposer).m_CameraDistance;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            
            if (componentBase is CinemachineFramingTransposer)
            {
                if (cameraDistance < 0)
                {
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
                    if ((componentBase as CinemachineFramingTransposer).m_CameraDistance > maxCameraDistance)
                    {
                        (componentBase as CinemachineFramingTransposer).m_CameraDistance = maxCameraDistance;
                    }
                }
                else
                {
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
                    if ((componentBase as CinemachineFramingTransposer).m_CameraDistance < 2)
                    {
                        (componentBase as CinemachineFramingTransposer).m_CameraDistance = 2;
                    }
                }
            }
            
        }
    }

    private void Follow3RdZoom()
    {
        if (componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
            maxCameraDistance = (componentBase as Cinemachine3rdPersonFollow).CameraDistance;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            
            if (componentBase is Cinemachine3rdPersonFollow follow)
            {
                if (cameraDistance < 0)
                {
                    follow.CameraDistance -= cameraDistance;
                    if (follow.CameraDistance > maxCameraDistance)
                    {
                        follow.CameraDistance= maxCameraDistance;
                    }
                }
                else
                {
                    follow.CameraDistance -= cameraDistance;
                    if (follow.CameraDistance < minCameraDistance)
                    {
                        follow.CameraDistance = minCameraDistance;
                    }
                }
            }
            
        }
    }
}
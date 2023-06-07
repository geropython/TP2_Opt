using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    
    //FIXEAR EL ZOOM IN Y EL ZOOM OUT
    public float zoomSpeed = 5f; // Velocidad de zoom
    public float minZoomDistance = 2f; // Distancia mínima de zoom (zoom out)
    public float maxZoomDistance = 10f; // Distancia máxima de zoom (zoom in)

    private Cinemachine.CinemachineFreeLook freeLookCamera; // Referencia al componente de la cámara

    private void Start()
    {
        // Obtener la referencia al componente de la cámara
        freeLookCamera = GetComponent<Cinemachine.CinemachineFreeLook>();
    }

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Si el usuario hace scroll hacia adelante, hace zoom in
        if (scrollInput > 0)
        {
            ZoomIn();
        }
        // Si el usuario hace scroll hacia atrás, hace zoom out
        else if (scrollInput < 0)
        {
            ZoomOut();
        }
    }

    void ZoomIn()
    {
        //TIRA NULL REFERENCE
        freeLookCamera.m_Lens.OrthographicSize = Mathf.Clamp(freeLookCamera.m_Lens.OrthographicSize - zoomSpeed, minZoomDistance, maxZoomDistance);
    }

    void ZoomOut()
    {
        //TIRA NULL REFERENCE
        freeLookCamera.m_Lens.OrthographicSize = Mathf.Clamp(freeLookCamera.m_Lens.OrthographicSize + zoomSpeed, minZoomDistance, maxZoomDistance);
    }
    
}
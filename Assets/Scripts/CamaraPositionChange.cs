using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPositionChange : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private List<Transform> camPositions;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TransformData(0);
        }if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TransformData(1);
        }if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TransformData(2);
        }if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TransformData(3);
        }
    }
    
    private void TransformData(int index)
    {
        var t = camPositions[index];
        cam.transform.SetPositionAndRotation(t.position,t.rotation);
    }
}

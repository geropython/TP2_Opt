using UnityEngine;    
public class CharacterZoomOrtho : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float zoomSpeed = 20f;
    [SerializeField] private float minCamSize = 5f;
    [SerializeField] private float maxCamSize = 20f;
    [SerializeField] private float sensitivity = 1;

    float targetZoom;

    private void Update()
    {
        Zoom();
    }
    
    private void Zoom()
    {
        // Get MouseWheel-Value and calculate new Orthographic-Size
        // (while using Zoom-Speed-Multiplier)
        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        float newZoomLevel = cam.orthographicSize - mouseScrollWheel;

        // Get Position before and after zooming
        Vector3 mouseOnWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        cam.orthographicSize = Mathf.Clamp(newZoomLevel, minCamSize, maxCamSize);
        Vector3 mouseOnWorld1 = cam.ScreenToWorldPoint(Input.mousePosition);

        // Calculate Difference between Positions before and after Zooming
        Vector3 posDiff = mouseOnWorld - mouseOnWorld1;

        // Add Difference to Camera Position
        Vector3 camPos = cam.transform.position;
        Vector3 targetPos = new Vector3(
            camPos.x + posDiff.x,
            camPos.y + posDiff.y,
            camPos.z);

        // Apply Target-Position to Camera
        cam.transform.position = targetPos;
    }
    
   
    void Start()
    {
        targetZoom = cam.orthographicSize;
    }
    
    private void Zoom2()
    {
        targetZoom -= Input.mouseScrollDelta.y * sensitivity;
        targetZoom = Mathf.Clamp(targetZoom, minCamSize, maxCamSize);
        float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
        cam.orthographicSize = newSize;
    }
    
    private float scroll = 0;        //Input axis of your scroll wheel.
    public float addedSpeed;    //Input axis doesnt have enough power to make camera zoom properly so we add it
    public float cameraSpeed;   //Lerp speed (PLAY AROUND WITH IT!)
 
    void Zoom3()
    {
        //If a scroll happens zoom or zoom out:
        scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize += scroll + addedSpeed;
 
 
        //IF youre zooming (IN) then lerp and zoom to your mouse position
        if (scroll < 0)
        {
            cam.transform.position = Vector2.Lerp(cam.transform.position,
                cam.ScreenToWorldPoint(Input.mousePosition),
                cameraSpeed * Time.deltaTime);
 
 
            //KEEP THE Z POSITION BEHIND YOUR OBJECTS!
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -20);
        }
 
        //If scroll > 0 then just zoom out but leave your camera at the position that it is. YOU CAN CHANGE THIS
    }

}

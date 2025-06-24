using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public Camera[] cameras;
    public float zoomSpeed = 10f;
    public float minFOV = 20f;
    public float maxFOV = 100f;

    void Start()
    {
        foreach (Camera cam in cameras)
        {
            if (cam != null)
                cam.fieldOfView = 60f;
        }
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            foreach (Camera cam in cameras)
            {
                if (cam != null)
                {
                    cam.fieldOfView -= scroll * zoomSpeed;
                    cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV);
                }
            }
        }
    }
}

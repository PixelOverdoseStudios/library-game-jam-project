using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private Vector3 dragOrigin;

    private float zoom;
    private float zoomMultipler = 4f;
    private float minZoom = 5;
    private float maxZoom = 12;
    private float velocity = 0f;
    private float smoothTime = 0.25f;

    [SerializeField]
    private SpriteRenderer cameraBoundsImage;

    private float boundsMinX, boundsMaxX, boundsMinY, boundsMaxY;

    private void Awake()
    {
        boundsMinX = cameraBoundsImage.transform.position.x - cameraBoundsImage.bounds.size.x / 2f;
        boundsMaxX = cameraBoundsImage.transform.position.x + cameraBoundsImage.bounds.size.x / 2f;

        boundsMinY = cameraBoundsImage.transform.position.y - cameraBoundsImage.bounds.size.y / 2f;
        boundsMaxY = cameraBoundsImage.transform.position.y + cameraBoundsImage.bounds.size.y / 2f;
    }

    private void Start()
    {
        zoom = cam.orthographicSize;
    }

    //Might have to call this function in Late Update() depending if there are any weird bugs.
    private void Update()
    {
        PanCamera();

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultipler;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        cam.transform.position = ClampCamera(cam.transform.position);
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(1))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(1))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position = ClampCamera(cam.transform.position + difference);
        }
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = boundsMinX + camWidth;
        float maxX = boundsMaxX - camWidth;
        float minY = boundsMinY + camHeight;
        float maxY = boundsMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}

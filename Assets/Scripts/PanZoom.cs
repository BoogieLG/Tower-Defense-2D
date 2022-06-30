using UnityEngine;

public class PanZoom : MonoBehaviour
{
    private Vector3 touchStart;
    public float zoomOutMin = 2;
    public float zoomOutMax = 8;
    public float zoomingSpeed = 2;
    public bool IsPanningZooming = false;
    public static PanZoom instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    private void Update()
    {
        float zooming = Input.GetAxis("Mouse ScrollWheel");
        if (zooming != 0) zoom(zooming);
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
            return;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (direction == Vector3.zero) return;
            Camera.main.transform.position += direction;
            IsPanningZooming = true;
            return;
        }
        IsPanningZooming = false;
    }

    private void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment*zoomingSpeed, zoomOutMin, zoomOutMax);
        IsPanningZooming = true;
    }
}

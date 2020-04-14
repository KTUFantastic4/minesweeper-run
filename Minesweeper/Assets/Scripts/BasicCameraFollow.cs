using UnityEngine;
using System.Collections;

public class BasicCameraFollow : MonoBehaviour 
{

	private Vector3 startingPosition;
	public Transform followTarget;
	private Vector3 targetPos;
	public float moveSpeed;
    //Zoom
    private bool isZoomed = false;
    private Camera cam;
    private float targetZoom;
    private float zoomFactor = 3f;
    [SerializeField] private float zoomLerpSpeed = 10;
    private Vector3 zoomed = new Vector3(4.3f, -3f, -10f);

    void Start()
	{
		startingPosition = transform.position;
        //Zoom
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

	void Update () 
	{
        //Zoom
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetKeyDown(KeyCode.M))
        {
            isZoomed = !isZoomed;
        }

        if (followTarget != null && !isZoomed)
		{
            targetZoom -= scrollData * zoomFactor;
            targetZoom = Mathf.Clamp(targetZoom, 2.5f, 8f);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);

            targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
			Vector3 velocity = (targetPos - transform.position) * moveSpeed;
			transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 10f, Time.deltaTime * zoomLerpSpeed);
            cam.transform.position = zoomed;// Vector3.SmoothDamp(cam.transform.position, zoomed, ref zoomed, 1.0f, Time.deltaTime*zoomLerpSpeed);            
        }
	}
}


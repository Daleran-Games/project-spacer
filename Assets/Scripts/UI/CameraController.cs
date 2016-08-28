using UnityEngine;
using System.Collections;



public class CameraController : MonoBehaviour {

	public float ROTStep;
	public float min;
	public float max;
	public float startZoom;

	public GameObject target;

	private Vector3 offset;
	private Camera cam;

	void Start () 
	{

        offset = new Vector3(0f, 0f, -16f);
        cam = gameObject.GetRequiredComponent<Camera> ();
		cam.orthographicSize = startZoom;

	}

    void Update ()
    {
        if (target == null)
        {
            GameObject t = GameObject.FindGameObjectWithTag("Player");
            if (t != null)
            {
                target = t;
            }
        }
    }

		

	void LateUpdate () 
	{
		if (target != null)
			transform.position = target.transform.position + offset;

		if (Input.GetAxis ("Mouse ScrollWheel") > 0)
			cam.orthographicSize -= ROTStep;
		else if (Input.GetAxis ("Mouse ScrollWheel") < 0)
			cam.orthographicSize += ROTStep;

		cam.orthographicSize = Mathf.Clamp (cam.orthographicSize, min, max);

	}
}

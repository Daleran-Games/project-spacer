using UnityEngine;
using System.Collections;



public class CameraController : MonoBehaviour {

	public float ROTStep;
	public float min;
	public float max;
	public float startZoom;

	public GameObject target;
    public PlayerController player;

	private Vector3 offset;
	private Camera cam;

    public float[] cameraLayerPresets;


	void Start () 
	{

        offset = new Vector3(0f, 0f, -5f);
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
                player = target.GetRequiredComponent<PlayerController>();
            }
        }
    }

		

	void LateUpdate () 
	{


        if (player.removeFloor == true)
            offset.z = 0.001f;
        else if (player.removeRoof == true)
            offset.z = -0.5f;
        else
            offset.z = -5f;


        if (target != null)
            transform.position = target.transform.position + offset;

        if (Input.GetAxis ("Mouse ScrollWheel") > 0)
			cam.orthographicSize -= ROTStep;
		else if (Input.GetAxis ("Mouse ScrollWheel") < 0)
			cam.orthographicSize += ROTStep;

		cam.orthographicSize = Mathf.Clamp (cam.orthographicSize, min, max);

	}
}

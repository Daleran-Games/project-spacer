using UnityEngine;

namespace ProjectSpacer
{

    public class CameraController : MonoBehaviour
    {



        public float ROTStep;
        public float min;
        public float max;
        public float startZoom;

        public GameObject target;


        private Vector3 offset;
        private Camera cam;

        public float[] layerPresets = new float[3] { 0.001f, -0.8f, -2.5f };
        private int currentLayer = 2;


        void Start()
        {
            offset = new Vector3(0f, 0f, layerPresets[currentLayer]);
            cam = gameObject.GetRequiredComponent<Camera>();
            cam.orthographicSize = startZoom;

        }

        void Update()
        {
            if (target == null)
            {
                GameObject t = GameObject.FindObjectOfType<PlayerController>().gameObject;
                if (t != null)
                {
                    target = t;
                }
            }
        }

        void LateUpdate()
        {

            if (GameManager.inputManger.layerDown.IsPressedOnce())
                MoveLayerDown();

            TrackTarget();

            if (GameManager.inputManger.mouseWheel.GetAxisValue() > 0)
                ZoomCameraIn();
            else if (GameManager.inputManger.mouseWheel.GetAxisValue() < 0)
                ZoomCameraOut();

        }

        public void TrackTarget()
        {
            if (target != null)
                transform.position = target.transform.position + offset;
        }

        public void MoveLayerUp()
        {
            if (currentLayer < layerPresets.Length - 1)
            {
                currentLayer++;
            }
            offset.z = layerPresets[currentLayer];
        }

        public void MoveLayerDown()
        {
            if (currentLayer > 0)
            {
                currentLayer--;
            } else if (currentLayer == 0)
            {
                currentLayer = layerPresets.Length - 1;
            }
            offset.z = layerPresets[currentLayer];
        }

        public void ZoomCameraIn()
        {
            cam.orthographicSize -= ROTStep;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, min, max);
        }

        public void ZoomCameraOut()
        {
            cam.orthographicSize += ROTStep;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, min, max);
        }


    }
}


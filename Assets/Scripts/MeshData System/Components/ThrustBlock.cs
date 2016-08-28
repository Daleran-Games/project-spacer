using UnityEngine;
using System.Collections;

[System.Serializable]
public class ThrustBlock {

	[SerializeField] public float up, down, right, left, cw, ccw;

	public ThrustBlock () {
		up = 0f;
		down = 0f;
		right = 0f;
		left = 0f;
		cw = 0f;
		ccw = 0f;
	}

	public ThrustBlock (float u, float d, float r, float l, float c, float w) {
		up = u;
		down = d;
		right = r;
		left = l;
		cw = c;
		ccw = w;
	}

	public float getTotalThrust () {

		return up - down -left + right;
	}

    public void Clear()
    {
        up = 0f;
        down = 0f;
        right = 0f;
        left = 0f;
        cw = 0f;
        ccw = 0f;
    }


}

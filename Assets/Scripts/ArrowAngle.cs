using UnityEngine;
using System.Collections;
using PixelArtRotation.Internal;
using PixelArtRotation;

public class ArrowAngle : MonoBehaviour {

    public PixelRotation rotation;
    public Rigidbody2D rb;

    Vector3 dir;
    public float angle;

    bool stuck;

	void Update () {
        if (!stuck)
        {
            dir = rb.velocity;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rotation.Angle = (int)angle + 180;
        }
	}

    public void Stuck(float storedAngle)
    {
        stuck = true;
        angle = storedAngle;
    }
}

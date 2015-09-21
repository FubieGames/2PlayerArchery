using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    public float maxPos = -5f;
    public float minPos = -10f;

    public float threshold = 0.025f;
    public float speed = 10;

    public bool up;


    void Start()
    {
        nextVector3 = this.transform.position;

        if (up)
        {
            nextPos = maxPos;
            GoUp();
        }
        else
        {
            nextPos = minPos;
            GoDown();
        }
    }
	
	void Update () {
        if (this.transform.position.y >= maxPos - (maxPos - nextPos))
        {
            nextPos = minPos;
            GoDown();
        }
        
        if (this.transform.position.y == minPos)
        {
            nextPos = maxPos - Random.Range(0f,3f);
            GoUp();
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, nextVector3, Time.deltaTime * speed);
	}

    void GoUp()
    {
        nextVector3 = new Vector3(this.transform.position.x, nextPos, this.transform.position.z);
    }

    void GoDown()
    {
        nextVector3 = new Vector3(this.transform.position.x, nextPos, this.transform.position.z);
    }

    Vector3 nextVector3;
    float nextPos;
}

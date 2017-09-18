using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {
    public bool moveInX;
    public bool moveInY;
    public float moveDistance;

    private float offsetx;
    private float offsety;

    private void Awake()
    {
        offsetx = transform.position.x;
        offsety = transform.position.y;
    }

    // Update is called once per frame
    void Update () {
        if (moveInX)
            transform.position = new Vector3(Mathf.PingPong(Time.time, moveDistance) + offsetx,
                            transform.position.y, transform.position.z);
        if (moveInY)
            transform.position = new Vector3(transform.position.x,
                            Mathf.PingPong(Time.time, moveDistance) + offsety, transform.position.z);
    }
}

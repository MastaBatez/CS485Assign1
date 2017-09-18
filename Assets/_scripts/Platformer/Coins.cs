using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

    public float coinRotationSpeed = 75f;
	
	// Update is called once per frame
	void Update () {
        float rotationAngle = coinRotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up * rotationAngle, Space.World);
	}
}

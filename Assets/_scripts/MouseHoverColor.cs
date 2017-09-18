using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().color = Color.black;
	}
	
	// Update is called once per frame
	void OnMouseEnter () {
        GetComponent<TextMesh>().color = Color.blue;
	}

    void OnMouseExit()
    {
        GetComponent<TextMesh>().color = Color.black;
    }
}

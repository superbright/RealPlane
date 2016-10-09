using UnityEngine;
using System.Collections;

public class Minimap_Camera : MonoBehaviour {
    Vector3 position;
    public float y_offset = 10f;
    public Camera theCamera; // set me in inspector

    void OnEnable () {
        position = transform.position;
        theCamera.farClipPlane = y_offset;
	}
	
	void Update () {
        position.x = Camera.main.transform.position.x;
        position.z = Camera.main.transform.position.z;
        position.y = Camera.main.transform.position.y + y_offset;
        transform.position = position;
	}
}

using UnityEngine;
using System.Collections;

public class BobScript : MonoBehaviour {
	Vector3 startPosition;
	float sin_counter = 0;
	public float y_offset = 2f;
	public float speed = 1f;
	public float rotSpeed = 90f;

    //public AudioSource spawnSound;

    // Use this for initialization
    void OnEnable () {
		startPosition = transform.position;
	}

	public void SetInitialPosition(Vector3 pos)
	{
		startPosition = pos;
	}

	// Update is called once per frame
	void FixedUpdate () {
	
		sin_counter+=speed;
		if (sin_counter > 360)
			sin_counter = 0;

		transform.position = new Vector3 (startPosition.x, startPosition.y + Mathf.Sin (sin_counter * Mathf.Deg2Rad) * y_offset, startPosition.z);

		transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotSpeed);




	}
}

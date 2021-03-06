﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;


public class IgalsTracking : MonoBehaviour {

	public ImageTargetBehaviour trackingmarker;


	public Vector3 locationoffset;
	public Quaternion rotationoffset;

	public bool isMovingObject = false;
	public bool isAnimating = false;

	public int smoothingFrames = 5;

	private Quaternion smoothedRotation;
	private Vector3 smoothedPosition;

	private Queue<Quaternion> rotations;
	private Queue<Vector3> positions;


	public void resetOffset() {
		locationoffset = this.transform.position;
	}
	// Use this for initialization
	void Start () {
		rotations = new Queue<Quaternion>(smoothingFrames);
		positions = new Queue<Vector3>(smoothingFrames);

		if (trackingmarker != null) {
			locationoffset = this.transform.position;
			rotationoffset = this.transform.rotation;
		}

	}
		
	
	// Update is called once per frame
	void Update () {
		if (trackingmarker != null && !isAnimating && trackingmarker.isActiveAndEnabled) {
			Vector3 v3 = new Vector3(trackingmarker.transform.position.x + locationoffset.x, trackingmarker.transform.position.y + locationoffset.y, trackingmarker.transform.position.z + locationoffset.z);
			Quaternion r3 = trackingmarker.transform.rotation * rotationoffset;

			if (rotations.Count >= smoothingFrames) {
				rotations.Dequeue();
				positions.Dequeue();
			}

			rotations.Enqueue(r3);
			positions.Enqueue(v3);

			Vector4 avgr = Vector4.zero;
			foreach (Quaternion singleRotation in rotations) {
				Math3d.AverageQuaternion(ref avgr, singleRotation, rotations.Peek(), rotations.Count);
			}

			Vector3 avgp = Vector3.zero;
			foreach (Vector3 singlePosition in positions) {
				avgp += singlePosition;
			}
			avgp /= positions.Count;

			smoothedRotation = new Quaternion(avgr.x, avgr.y, avgr.z, avgr.w);
			smoothedPosition = avgp;

			transform.position = smoothedPosition;
			transform.rotation = smoothedRotation;
		}

	
	}
	// Update is called once per frame

}

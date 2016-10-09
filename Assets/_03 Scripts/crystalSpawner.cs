using UnityEngine;
using System.Collections;

public class crystalSpawner : MonoBehaviour {


	public float radius; 
	public float spawnTime;
	public int maxNum;
	public float spawn_y = 1f;

	public GameObject[] Crystals;

	private float lastSpawnTime;
		
	ArrayList spawnedObjects;

	// Use this for initialization
	void OnEnable () {
	
		spawnedObjects = new ArrayList();
		lastSpawnTime = Time.realtimeSinceStartup;
	}

	void spawnSomething()
	{
		

		/* then, instantiate a copy of the crystal */

		GameObject newObj = Instantiate (Crystals[Random.Range(0, Crystals.Length - 1)]);
		Vector3 newpos = transform.position;
		newpos.x += Random.Range (-1 * radius, radius);
		newpos.z += Random.Range (-1 * radius, radius);
		newpos.y = spawn_y;

		BobScript bs = newObj.GetComponent<BobScript> ();

		if (bs == null) {
			Debug.Log ("Asked to spawn some garbage");
		} else {
			bs.SetInitialPosition (newpos);
		}

		/* add it to my tracked list */
		spawnedObjects.Add (newObj);

		lastSpawnTime = Time.realtimeSinceStartup;
	}

	// Update is called once per frame
	void FixedUpdate () {
	
		if (Time.realtimeSinceStartup - lastSpawnTime > spawnTime)
		{
			/* first,go through spawned objects and remove any nulls */
			for (int i = 0; i < spawnedObjects.Count; i++) {
				if (spawnedObjects [i] == null) {
					spawnedObjects.RemoveAt (i);
				}
			}

			if (spawnedObjects.Count < maxNum) {
				spawnSomething ();
			}
		}

	}
}

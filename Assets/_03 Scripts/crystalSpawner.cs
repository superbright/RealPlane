using UnityEngine;
using System.Collections;

public class crystalSpawner : MonoBehaviour {


	public float radius = 5f;
    public float min_radius = 2f;
	public float spawnTime = 5f;
	public int maxNum = 5;
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

        // get random distance and angle;

        float distance = Random.Range(min_radius, radius);
        float angle = Random.Range(0, 360f * Mathf.Deg2Rad);

        Vector2 point = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        point *= distance;

        newpos.x += point.x;
        newpos.z += point.y;
        
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
                GameObject go = (GameObject)spawnedObjects[i];

                if (go == null || go.Equals(null)) {
					spawnedObjects.RemoveAt (i);
				}
			}

			if (spawnedObjects.Count < maxNum) {
				spawnSomething ();
			}
		}

	}
}

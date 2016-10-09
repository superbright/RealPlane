using UnityEngine;
using System.Collections;

public class Fadeoutafter : MonoBehaviour {

    float starttime;
    public float fade_after = 5f;
    public float fade_time = 1f;
    // Use this for initialization
	void Start () {
        starttime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
        float pct = ((Time.realtimeSinceStartup - starttime - fade_after) / fade_time);
        if (pct > 0f)
        {
            
            MeshRenderer mr = GetComponent<MeshRenderer>();
            mr.material.SetColor("_Color", new Color(1f, 1f, 1f, 1 - pct));
            if (pct > 1.0f)
            {
                Destroy(gameObject);
            }
        }
	}
}

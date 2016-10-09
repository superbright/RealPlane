using UnityEngine;
using System.Collections;
using Vuforia;

public class AngleTracker : MonoBehaviour {

    public DefaultTrackableEventHandler tracker;
    public ImageTargetBehaviour trackingmarker;
   // public UnityEngine.UI.Text display1;
    public GameObject scanner;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   // if(display1 !=null)
       // {
           //display1.text = "x: " + transform.rotation.eulerAngles.x + " y: " + transform.rotation.eulerAngles.y + " z: " + transform.rotation.eulerAngles.z;
           //Debug.Log(display1.text);
       // }
        if (transform.rotation.eulerAngles.x > 330 && tracker.isTracking)
        {
            gameObject.GetComponentInChildren<Renderer>().enabled = true;
            scanner.SetActive(false);
        } else
        {
            gameObject.GetComponentInChildren<Renderer>().enabled = false;
            scanner.SetActive(true);
        }
	}
}

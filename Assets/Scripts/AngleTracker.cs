using UnityEngine;
using System.Collections;

public class AngleTracker : MonoBehaviour {

    public UnityEngine.UI.Text display1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(display1 !=null)
        {
            display1.text = "x: " + transform.rotation.eulerAngles.x + " y: " + transform.rotation.eulerAngles.y + " z: " + transform.rotation.eulerAngles.z;
            //Debug.Log(display1.text);
        }
	}
}

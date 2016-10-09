using UnityEngine;
using System.Collections;

public class TriggerHandler : MonoBehaviour {

    public TestBLE bleHandler;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered " + other.gameObject.name);
        //haptic
        if(bleHandler != null && bleHandler.btlec.am_connected())
        {
            bleHandler.RxBTLE("71");
        }
      //  LeanTween.rotateAround(other.gameObject, Vector3.left, 45f, 4.0f);
        LeanTween.moveLocal(other.gameObject, new Vector3(0, 0.5f, 0), 1.0f).setOnComplete(
            () =>
            {
                LeanTween.moveLocal(other.gameObject, new Vector3(0, 0f, 0), 1.0f).setDelay(0.5f);
            }
            );
      
    }
}

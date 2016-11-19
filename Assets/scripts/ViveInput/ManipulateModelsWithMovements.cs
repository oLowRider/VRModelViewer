using UnityEngine;
using System.Collections;

public class ManipulateModelsWithMovements : MonoBehaviour {

    public GameObject Tracer;

    public SteamVR_Controller.Device controller;
    private SteamVR_TrackedObject trackedObj;

    void Start ()
    {
        controller = GetComponent<ClickonCollider>().controller;
	}
	
	void FixedUpdate ()
    {
	    while(controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log("Gripped");
            Tracer.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, controller.transform.pos.x);
        }
	}
}

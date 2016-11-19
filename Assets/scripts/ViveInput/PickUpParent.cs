using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Hand Controllers.
/// </summary>
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickUpParent : MonoBehaviour
{
    public Transform flashlight;

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    bool isTriggerDown = false;

    //
    SteamVR_LaserPointer laserPointer;

    Button btn;
    Toggle tgl;
    Slider sld;

    private int deviceIndex = -1;
    private SteamVR_Controller.Device controller;

    bool pointerOnButton = false;
    bool pointerOnToggle = false;
    bool pointerOnSlider = false;
    
    //For lifting objects
    bool isHit = true;

    GameObject myEventSystem;
    int layerButtons;

    void Awake ()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
    void Start()
    {
        myEventSystem = GameObject.Find("EventSystem");
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn += LaserPointer_PointerIn;
        laserPointer.PointerOut += LaserPointer_PointerOut;

        layerButtons = LayerMask.NameToLayer("Buttons");
    }

	void FixedUpdate ()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        isTriggerDown = device.GetTouch(SteamVR_Controller.ButtonMask.Trigger);

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("Holding trigger");
        }

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("Activated TouchDown");
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("Activated TouchUp");
        }

        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("Holding Press");
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("Activated PressDown with Trigger");
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("Activated PressUp with Trigger");
        }


        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Debug.Log("Activated PressUp with Touchpad");

            flashlight.transform.position = new Vector3(0, 0.8f, 0);
            flashlight.GetComponent<Rigidbody>().velocity = Vector3.zero;
            flashlight.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        if (pointerOnButton)
        {
            Debug.Log("Execute PointerOnButton");
            if (controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                Debug.Log(btn);
                btn.onClick.Invoke();
                //btn = null;
            }
        }

        if (pointerOnToggle)
        {
            if (controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                Debug.Log("Execute PointerOnToggle");
                ExecuteEvents.Execute<IPointerClickHandler>(tgl.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                tgl = null;
            }
        }

        if (pointerOnSlider)
        {
            Debug.Log("Aiming at Slider collider");
            while (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Execute PointerOnSlider");
                sld.value = trackedObj.transform.localPosition.x * Time.deltaTime;
                //sld = null;
                Debug.Log(trackedObj.transform.localPosition.x);
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log("Testing");
        if(isTriggerDown)
        {
            col.attachedRigidbody.isKinematic = true;
            this.GetComponent<SphereCollider>().isTrigger = true;
            col.gameObject.transform.SetParent(this.gameObject.transform);
        }

        if(isTriggerDown == false)
        {
            col.gameObject.transform.SetParent(null);

            col.attachedRigidbody.isKinematic = false;

            tossObject(col.attachedRigidbody);
        }

        do
        {
            this.GetComponent<SphereCollider>().isTrigger = false;
        }
        while (isHit);
    }

    void OnTriggerExit(Collider col)
    {
        isHit = false;
    }

    void tossObject(Rigidbody rb)
    {
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            rb.velocity = origin.TransformVector(device.velocity);
            rb.angularVelocity = origin.TransformVector(device.angularVelocity);            
        }
        else
        {
            rb.velocity = device.velocity;
            rb.angularVelocity = device.angularVelocity;
        }
    }

    private void SetDeviceIndex(int index)
    {
        deviceIndex = index;
        controller = SteamVR_Controller.Input(index);
    }
    private void LaserPointer_PointerOut(object sender, PointerEventArgs e)
    {
        if (btn != null)
        {
            pointerOnButton = false;
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
            //btn = null;
        }
    }

    private void LaserPointer_PointerIn(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.GetComponent<Button>() != null && btn == null)
        {
            btn = e.target.gameObject.GetComponent<Button>();
            btn.Select();
            //Debug.Log("Selecting Button");

            pointerOnButton = true;
        }

        if (e.target.gameObject.GetComponent<Toggle>())
        {
            tgl = e.target.gameObject.GetComponent<Toggle>();
            tgl.Select();

            pointerOnToggle = true;
        }

        if(e.target.gameObject.GetComponentInParent<Slider>())
        {
            sld = e.target.gameObject.GetComponentInParent<Slider>();
            sld.Select();

            pointerOnSlider = true;
        }
        else
        {
            pointerOnSlider = false;
        }

        if(e.target.gameObject.tag == "Buttons")
        {
 
        }
    }

    public void TestMethod()
    {
        Debug.Log("TestMethod OnClick Button Active");
    }
}

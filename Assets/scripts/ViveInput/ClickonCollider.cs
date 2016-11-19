using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

/// <summary>
/// Script which goes hand in hand with the hi-jacked SteamVR_Teleporter. Used to teleport & change environments
/// </summary>
public class ClickonCollider : MonoBehaviour
{
    public GameObject LowPoly, LowPolyTeleportArea;
    public GameObject Bedroom, TeleportArea;
    public GameObject DarkRoom, DRTeleportArea;
    public GameObject JapRoom, JapTeleportArea;
    public GameObject ParkingRoom, ParkingTeleportArea;
    public GameObject BookersOffice, BookerOfficeTeleportArea;

    SteamVR_LaserPointer laserPointer;

    Button btn;
    Button boxBtn;
    Toggle tgl;
    Slider sld;

    private int deviceIndex = -1;
    public SteamVR_Controller.Device controller;
    private SteamVR_TrackedObject trackedObj;

    bool pointerOnButton = false;
    bool pointerOnToggle = false;
    bool pointerOnBoxButton = false;
    bool pointerOnSlider = false;
    bool pointerOnFloor = false;
    public bool teleportPressed = false;

    bool rangeOfBoob = false;

    bool canLiftInteractable = false;
    GameObject interactableObject;
    Transform interactableObjectParent;

    GameObject myEventSystem;
    int layerButtons;
    private float currentRot;

    void Start()
    {
        myEventSystem = GameObject.Find("EventSystem");
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn += LaserPointer_PointerIn;
        laserPointer.PointerOut += LaserPointer_PointerOut;

        TeleportArea.SetActive(false);
        DRTeleportArea.SetActive(false);
        JapTeleportArea.SetActive(false);
        ParkingTeleportArea.SetActive(false);
        BookerOfficeTeleportArea.SetActive(false);

        layerButtons = LayerMask.NameToLayer("Buttons");
    }
    public void SetDeviceIndex(int index)
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
            btn = null;
        }
    }

    /// <summary>
    /// Detect if Laser Pointer is aiming at. For Buttons, Toggles, Sliders & Floor colliders
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LaserPointer_PointerIn(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.GetComponent<Button>() && e.target.gameObject.GetComponent<CapsuleCollider>() /*!= null && btn == null*/)
        {
            btn = e.target.gameObject.GetComponent<Button>();
            btn.Select();
            //Debug.Log(btn.name + " GetComponent()");

            pointerOnButton = true;
        }
        if (e.target.gameObject.GetComponent<Button>() && e.target.gameObject.GetComponent<BoxCollider>())
        {
            boxBtn = e.target.gameObject.GetComponent<Button>();
            boxBtn.Select();
            pointerOnBoxButton = true;
        }
        else
        {            
            pointerOnBoxButton = false;
        }

        if (e.target.gameObject.GetComponent<Toggle>() && e.target.gameObject.GetComponent<Collider>())
        {
            tgl = e.target.gameObject.GetComponent<Toggle>();
            tgl.Select();
            //Debug.Log(tgl.name + " GetComponent()");

            pointerOnToggle = true;
        }
        else
        {
            pointerOnToggle = false;
        }
        if(e.target.gameObject.GetComponent<CapsuleCollider>() && e.target.GetComponent<Slider>())
        {
            Debug.Log("TracerScaleSlider");
            sld = e.target.gameObject.GetComponent<Slider>();
            //sld.Select();
            Debug.Log(sld.name + " GetComponent");
            currentRot = this.transform.localRotation.y;            
            pointerOnSlider = true;
        }
        else
        {
            pointerOnSlider = false;
        }

        if(e.target.gameObject.tag == "Floor")
        {
            pointerOnFloor = true;
            //Debug.Log(pointerOnFloor);
        }
        else
        {
            pointerOnFloor = false;
        }
    }

    void FixedUpdate()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        controller = SteamVR_Controller.Input((int)trackedObj.index);

        if (pointerOnButton)
        {
            if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                btn.onClick.Invoke();
                btn = null;

                pointerOnButton = false;
            }
        }
        if (pointerOnBoxButton)
        {
            if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                boxBtn.onClick.Invoke();
            }
        }

        if (pointerOnToggle)
        {
            if(controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                ExecuteEvents.Execute<IPointerClickHandler>(tgl.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                tgl = null;
            }           
        }

        if (pointerOnFloor && (!pointerOnButton || !pointerOnBoxButton || !pointerOnToggle))
        {
            if(LowPoly.activeInHierarchy)
            {
                if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    LowPolyTeleportArea.SetActive(true);
                }

            }
            if (Bedroom.activeInHierarchy)
            {
                if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    TeleportArea.SetActive(true);
                }
            }
            if(DarkRoom.activeInHierarchy)
            {
                if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    DRTeleportArea.SetActive(true);
                }
            }
            if(JapRoom.activeInHierarchy)
            {
                if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    JapTeleportArea.SetActive(true);
                }
            }
            if(ParkingRoom.activeInHierarchy)
            {
                if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    ParkingTeleportArea.SetActive(true);
                }
            }
            if(BookersOffice.activeInHierarchy)
            {
                if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    BookerOfficeTeleportArea.SetActive(true);
                }
            }

            if(controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                //Invoke Teleport
                teleportPressed = true;
                this.GetComponent<SteamVR_Teleporter>().teleportOnClick = true;

                LowPolyTeleportArea.SetActive(false);
                TeleportArea.SetActive(false);
                DRTeleportArea.SetActive(false);
                JapTeleportArea.SetActive(false);
                ParkingTeleportArea.SetActive(false);
                BookerOfficeTeleportArea.SetActive(false);
            }            
        }
        if(pointerOnFloor == false)
        {
            pointerOnFloor = false;
            LowPolyTeleportArea.SetActive(false);
            TeleportArea.SetActive(false);
            DRTeleportArea.SetActive(false);
            JapTeleportArea.SetActive(false);
            BookerOfficeTeleportArea.SetActive(false);
        }

        if(canLiftInteractable)
        {
            if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Picked Up InteractableObject: " + interactableObject);
                interactableObject.transform.parent = this.gameObject.transform;
                interactableObject.transform.rotation = this.gameObject.transform.rotation;

                interactableObject.GetComponent<Rigidbody>().isKinematic = true;
                interactableObject.GetComponent<Rigidbody>().useGravity = false;
                //interactableObject.GetComponent<MeshCollider>().isTrigger = true;
                //this.GetComponent<SphereCollider>().isTrigger = true;
            }
            if (controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Dropped Interactable: " + interactableObject);
                interactableObject.GetComponent<Rigidbody>().isKinematic = false;
                interactableObject.GetComponent<Rigidbody>().useGravity = true;
                //canLiftInteractable = false;

                DropHoldingObject();

                interactableObject.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * Time.deltaTime;

                if (interactableObject.name == "HarleyProp-Bat")
                {
                    interactableObject.transform.parent = null;
                }
                if(interactableObject.name == "Flashlight")
                {
                    Debug.Log("Running Flashlight double check");
                    interactableObject.transform.parent = null;
                }
            }
        }

        if (this.GetComponent<SteamVR_TrackedController>().triggerPressed && interactableObject != null)
        {
            if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                Vector3 resetValue = new Vector3(90f, 0f, 0f);

                interactableObject.transform.position = this.transform.position;
                interactableObject.transform.localEulerAngles = resetValue;
            }
        }
    }

    void DropHoldingObject()
    {
        this.GetComponent<SphereCollider>().isTrigger = false;  //Otherwise letting go of objects freezes them in air

        interactableObject.transform.parent = null; //Null to make life easier. Long term, use this: "interactableObjectParent.transform.parent"
        canLiftInteractable = false;
        interactableObject = null;
        interactableObjectParent = null;
        interactableObjectParent.transform.parent = null;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Interactable" && interactableObject == null)
        {
            canLiftInteractable = true;
            //interactableObjectParent.transform.parent = col.gameObject.transform.parent;    
            
            interactableObject = col.gameObject;
            //interactableObjectParent = col.gameObject.transform.parent;
            //this.GetComponent<SphereCollider>().isTrigger = true;

            Debug.Log("Collided obect: " + col);
        }

        if(col.gameObject.tag == "Boobs" && interactableObject == null)
        {
            interactableObject = col.gameObject;
            rangeOfBoob = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Interactable")
        {
            Debug.Log("Not Colliding with " + col);
            this.GetComponent<SphereCollider>().isTrigger = false;  //Otherwise letting go of objects freezes them in air
        }
    }
}
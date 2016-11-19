using UnityEngine;
using System.Collections;

public struct PointerEventArgs
{
    public uint controllerIndex;
    public uint flags;
    public float distance;
    public Transform target;
}

public delegate void PointerEventHandler(object sender, PointerEventArgs e);


public class SteamVR_LaserPointer : MonoBehaviour
{
    public bool active = true;
    public float thickness = 0.002f;
    public GameObject holder;
    public GameObject pointer;
    bool isActive = false;
    public bool addRigidBody = false;
    public Transform reference;
    public event PointerEventHandler PointerIn;
    public event PointerEventHandler PointerOut;

    SteamVR_TrackedObject trackedObj;
    Transform previousContact = null;
    SteamVR_Controller.Device device;

    private int LayerButtons;
    Material newMaterial;
    Color color;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start ()
    {    
        holder = new GameObject();
        holder.transform.parent = this.transform;
        holder.transform.localPosition = Vector3.zero;        

        pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pointer.GetComponent<BoxCollider>().enabled = false;
        Destroy(pointer.GetComponent<Rigidbody>());
        pointer.transform.parent = holder.transform;
        pointer.transform.localScale = new Vector3(thickness, thickness, 50f); //Scale of Raycast Line        
        pointer.transform.localPosition = new Vector3(0f, 0f, 25f); //Position of Raycast Line
        pointer.layer = 10;
        BoxCollider collider = pointer.GetComponent<BoxCollider>();
        if (addRigidBody)
        {
            if (collider)
            {
                collider.isTrigger = true;
            }
            Rigidbody rigidBody = pointer.AddComponent<Rigidbody>();
            rigidBody.isKinematic = true;
        }
        else
        {
            if(collider)
            {
                Object.Destroy(collider);
            }
        }
        newMaterial = new Material(Shader.Find("Unlit/Color"));
        color = new Color(0, 233, 255);
        newMaterial.SetColor("_Color", color);
        pointer.GetComponent<MeshRenderer>().material = newMaterial;
        pointer.SetActive(true);
	}

    public virtual void OnPointerIn(PointerEventArgs e)
    {
        if (PointerIn != null)
            PointerIn(this, e);
    }

    public virtual void OnPointerOut(PointerEventArgs e)
    {
        if (PointerOut != null)
            PointerOut(this, e);
    }


    // Update is called once per frame
	void FixedUpdate ()
    {
        SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();

        if (!isActive)
        {
            isActive = true;
            this.transform.GetChild(0).gameObject.SetActive(true);
        }

        float dist = 100f;

        Ray raycast = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        bool bHit = Physics.Raycast(raycast, out hit);

        if (previousContact && previousContact != hit.transform)
        {
            PointerEventArgs args = new PointerEventArgs();
            if (controller != null)
            {
                args.controllerIndex = controller.controllerIndex;
            }
            args.distance = 0f;
            args.flags = 0;
            args.target = previousContact;
            OnPointerOut(args);
            previousContact = null;
        }

        //If Line hits something
        if(bHit && previousContact != hit.transform)
        {
            PointerEventArgs argsIn = new PointerEventArgs();
            if (controller != null)
            {
                argsIn.controllerIndex = controller.controllerIndex;
            }
            argsIn.distance = hit.distance;
            argsIn.flags = 0;
            argsIn.target = hit.transform;
            OnPointerIn(argsIn);
            previousContact = hit.transform;
        }

        if (!bHit)
        {
            previousContact = null;
        }
        if (bHit && hit.distance < 100f)
        {
            dist = hit.distance;
        }
    }
}

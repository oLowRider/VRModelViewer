using UnityEngine;
using System.Collections;

/// <summary>
/// Script which controls teleport. I hijacked the SteamVR_Teleporter instead of creating a new script
/// </summary>
public class SteamVR_Teleporter : MonoBehaviour
{
    public enum TeleportType
    {
        TeleportTypeUseTerrain,
        TeleportTypeUseCollider,
        TeleportTypeUseZeroY
    }

    public GameObject LowPoly;
    public GameObject Bedroom;
    public GameObject DarkRoom;
    public GameObject JapRoom;
    public GameObject ParkingLot;
    public GameObject BookersOffice;

    public bool teleportOnClick = false;

    public BoxCollider LowPolyDetect;
    public BoxCollider TeleportFloorDetect;
    public BoxCollider DRFloorDetect;
    public BoxCollider JapFloorDetect;
    public BoxCollider ParkingFloorDetect;
    public BoxCollider BookersOfficeDetect;

    public TeleportType teleportType = TeleportType.TeleportTypeUseZeroY;
    public Transform reference;
    private SteamVR_Controller.Device controller;

    void Start ()
    {
        Transform eyeCamera = GameObject.FindObjectOfType<SteamVR_Camera>().GetComponent<Transform>();
        // The referece point for the camera is two levels up from the SteamVR_Camera
        //reference = eyeCamera.parent.parent;

        if (GetComponent<SteamVR_TrackedController>() == null)
        {
            Debug.LogError("SteamVR_Teleporter must be on a SteamVR_TrackedController");
            return;
        }
        GetComponent<SteamVR_TrackedController>().PadUnclicked += new ClickedEventHandler(DoClick);

        if (teleportType == TeleportType.TeleportTypeUseTerrain)
        {
            // Start the player at the level of the terrain
            reference.position = new Vector3(reference.position.x, 0f, reference.position.z); //Terrain.activeTerrain.SampleHeight(reference.position)
        }
	}
	
	void FixedUpdate()
    {
        //if (gameObject.GetComponent<ClickonCollider>().teleportPressed)
        //{
        //    teleportOnClick = true;
        //}
    }

    public void DoClick(object sender, ClickedEventArgs e)
    {
        if (teleportOnClick)
        {
            bool teleportP = this.GetComponent<ClickonCollider>().teleportPressed;

            // Teleport
            float refY = reference.position.y;

            Plane plane = new Plane(Vector3.up, -refY);
            Ray ray = new Ray(this.transform.position, transform.forward);

            Debug.DrawRay(transform.position, transform.forward, Color.green);

            bool hasGroundTarget = false;
            float dist = 0f;
            if (teleportType == TeleportType.TeleportTypeUseTerrain)
            {
                RaycastHit hitInfo;
                //TerrainCollider tc = Terrain.activeTerrain.GetComponent<TerrainCollider>();
                if(LowPoly.activeInHierarchy)
                {
                    hasGroundTarget = LowPolyDetect.Raycast(ray, out hitInfo, 1000f);
                    dist = hitInfo.distance;
                }
                if (Bedroom.activeInHierarchy)
                {
                    hasGroundTarget = TeleportFloorDetect.Raycast(ray, out hitInfo, 1000f);
                    dist = hitInfo.distance;
                }
                if (DarkRoom.activeInHierarchy)
                {
                    hasGroundTarget = DRFloorDetect.Raycast(ray, out hitInfo, 1000f);
                    dist = hitInfo.distance;
                }
                if (JapRoom.activeInHierarchy)
                {
                    hasGroundTarget = JapFloorDetect.Raycast(ray, out hitInfo, 1000f);
                    dist = hitInfo.distance;
                }
                if(ParkingLot.activeInHierarchy)
                {
                    hasGroundTarget = ParkingFloorDetect.Raycast(ray, out hitInfo, 1000f);
                    dist = hitInfo.distance;
                }
                if(BookersOffice.activeInHierarchy)
                {
                    hasGroundTarget = BookersOfficeDetect.Raycast(ray, out hitInfo, 1000f);
                    dist = hitInfo.distance;
                }
            }
            else if (teleportType == TeleportType.TeleportTypeUseCollider)
            {
                RaycastHit hitInfo;
                Physics.Raycast(ray, out hitInfo);
                dist = hitInfo.distance;
            }
            else
            {
                hasGroundTarget = plane.Raycast(ray, out dist);
            }
            //Debug.Log("hasGroundTarget = " + hasGroundTarget);
            if (hasGroundTarget)
            {
                Vector3 newPos = ray.origin + ray.direction * dist - new Vector3(reference.GetChild(0).localPosition.x, 0f, reference.GetChild(0).localPosition.z) /*Correction of orig new Vector3(-1.4f,0f,1.4f)*/;

                reference.position = newPos;
            }

            //teleportOnClick = false;
        }
    }
}
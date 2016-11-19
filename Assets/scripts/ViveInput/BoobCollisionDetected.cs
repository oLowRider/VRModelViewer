using UnityEngine;
using System.Collections;

public class BoobCollisionDetected : MonoBehaviour {

    public float speed = 1.0f;
    public float rotSpeed = 1.0f;

    Vector3 origPosition;
    Quaternion origRotation;
    Vector3 lastPosition;
    Quaternion lastRotation;
    Vector3 modelScale;

    GameObject Ciri;
    Rigidbody rigidBody;

    private int deviceIndex = -1;

    void Start ()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        origPosition = this.transform.localPosition;
        origRotation = this.transform.rotation;
        modelScale = this.transform.lossyScale;
        Debug.Log("ModelScale Start: " + modelScale);
    }

    void FixedUpdate ()
    {
        lastPosition = this.transform.localPosition;
        lastRotation = this.transform.localRotation;

        if (this.transform.localPosition != origPosition)
        {
            this.transform.localPosition = Vector3.Lerp(transform.localPosition, origPosition, 0.1f);
        }
        if (this.transform.rotation != origRotation)
        {
            this.transform.rotation = Quaternion.Slerp(transform.rotation, origRotation, 0.1f);
        }
    }

    //Keep just in case wanna reuse. It's for picking up and setting down objects

    //void OnCollisionEnter(Collision col)
    //{
    //    if(col.gameObject.name == "Controller (right)")
    //    {
    //        Debug.Log("detected hit on boob");
    //        GameObject.Find("Controller (right)").GetComponent<ClickonCollider>().CollidedWithBoobEnter(this.gameObject);
    //    }
    //}

    //void OnCollisionExit(Collision col)
    //{
    //    if(col.gameObject.name == "Controller (right)")
    //    {
    //        Debug.Log("Controller left collider");
    //        GameObject.Find("Controller (right)").GetComponent<ClickonCollider>().CollidedWithBoobExit(this.gameObject, origPosition, origRotation);
    //    }
    //}
}

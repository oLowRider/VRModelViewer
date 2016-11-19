using UnityEngine;
using System.Collections;

public class BoobCollider : MonoBehaviour {

    public Transform original;
    public Transform current;

    public float speed = 0.1f;

    void Start ()
    {
        original = this.transform;
	}

    void LateUpdate()
    {
        current = this.transform;
        transform.rotation = Quaternion.Slerp(original.rotation, current.rotation, Time.deltaTime * speed);
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    inRange = true;
    //}

    //void OnCollisionExit(Collision col)
    //{
    //    inRange = false;
    //}

}

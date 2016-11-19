using UnityEngine;
using System.Collections;

public class RefreshTransform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        this.transform.localPosition = new Vector3(0, 0, 0.1f);
	}
}

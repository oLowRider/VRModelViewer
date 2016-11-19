using UnityEngine;
using System.Collections;

public class CursorHit : MonoBehaviour {

    public HeadLookController[] HLCArray;
    public bool headLookEnabled = true;

    private float offset = 1.5f;

	void LateUpdate () {
		//if (Input.GetKey(KeyCode.UpArrow))
		//	offset += Time.deltaTime;
		//if (Input.GetKey(KeyCode.DownArrow))
		//	offset -= Time.deltaTime;
		
        //
		//Ray cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		//RaycastHit hit;
		//if (Physics.Raycast(cursorRay, out hit)) {
		//	transform.position = hit.point + offset * Vector3.up;
		//}
        if(headLookEnabled)
        {
            foreach (HeadLookController hlc in HLCArray)
            {
                hlc.target = transform.position;
            }
        }
        else
        {
            foreach (HeadLookController hlc in HLCArray)
            {
                hlc.target = Vector3.zero;
            }
        }
    }
}

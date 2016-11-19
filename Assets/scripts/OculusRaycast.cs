using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;

public class OculusRaycast : MonoBehaviour {

    Button btn;
    Button boxBtn;
    Toggle tgl;
    Slider sld;

    SteamVR_LaserPointer laserPointer;

    bool pointerOnButton = false;
    bool pointerOnToggle = false;
    bool pointerOnBoxButton = false;
    bool pointerOnSlider = false;
    bool pointerOnUI = false;

    GameObject myEventSystem;

    void Start ()
    {
        myEventSystem = GameObject.Find("EventSystem");
        laserPointer = GameObject.Find("Camera (eye)").GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn += LaserPointer_PointerIn;
        laserPointer.PointerOut += LaserPointer_PointerOut;
    }
	
	void FixedUpdate ()
    {
        //onClick.Invoke();
        Ray ray = new Ray(this.transform.position, transform.forward);
        RaycastHit hitInfo;

        if(pointerOnUI)
        {
            //Debug.Log("Looking at UI");
        }

        if(pointerOnButton)
        {
            if(CrossPlatformInputManager.GetButton("GamepadAButton"))
            {
                btn.onClick.Invoke();
                btn = null;

                pointerOnButton = false;
            }
        }

        if (pointerOnBoxButton)
        {
            if(CrossPlatformInputManager.GetButton("GamepadAButton"))
            {
                boxBtn.onClick.Invoke();
            }
        }

        if (pointerOnToggle)
        {
            if(CrossPlatformInputManager.GetButton("GamepadAButton"))
            {
                ExecuteEvents.Execute<IPointerClickHandler>(tgl.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                tgl = null;
            }
        }
    }

    private void LaserPointer_PointerIn(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.GetComponent<Button>() && e.target.gameObject.GetComponent<CapsuleCollider>() /*!= null && btn == null*/)
        {
            btn = e.target.gameObject.GetComponent<Button>();
            btn.Select();

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

            pointerOnToggle = true;
        }
        else
        {
            pointerOnToggle = false;
        }

        if (e.target.gameObject.GetComponent<CapsuleCollider>() && e.target.GetComponent<Slider>())
        {
            sld = e.target.gameObject.GetComponent<Slider>();
            //sld.Select();
            pointerOnSlider = true;
        }
        else
        {
            pointerOnSlider = false;
        }

        if (e.target.gameObject.layer == 5)
        {
            pointerOnUI = true;
        }
        else
        {
            pointerOnUI = false;
        }

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
}

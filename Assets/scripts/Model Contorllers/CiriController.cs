using UnityEngine;
using System.Collections;

public class CiriController : MonoBehaviour {

    public GameObject Belt;
    [SerializeField]
    bool beltEnabled;

    public GameObject Scabbard;
    [SerializeField]
    bool scabbardEnabled;

    public GameObject Clothes;
    [SerializeField]
    bool clothesEnabled;

    public GameObject Body;
    [SerializeField]
    bool bodyEnabled;

    public GameObject Necklace;
    [SerializeField]
    bool necklaceEnabled;

    public Animator CiriAnimator;

    GameObject LHandController;
    GameObject RHandController;

    SteamVR_TrackedController LHandControllerTC;
    SteamVR_TrackedController RHandControllerTC;

    void Start ()
    {
        Belt.SetActive(beltEnabled);
        Scabbard.SetActive(scabbardEnabled);
        Clothes.SetActive(clothesEnabled);
        Body.SetActive(bodyEnabled);
        Necklace.SetActive(necklaceEnabled);

        LHandController = GameObject.Find("Controller (left)");
        RHandController = GameObject.Find("Controller (right)");
        LHandControllerTC = LHandController.GetComponent<SteamVR_TrackedController>();
        RHandControllerTC = RHandController.GetComponent<SteamVR_TrackedController>();
    }

    void FixedUpdate()
    {
        if(LHandControllerTC.gripped && RHandControllerTC.gripped)
        {
            Vector3 orignPos = LHandController.transform.position;
        }
    }


    public void CiriChangeToIdle(bool value)
    {
        if (value)
        {
            CiriAnimator.SetBool("CiriIdleIsTicked", true);
            CiriAnimator.SetBool("Ciripose1IsTicked", false);
            CiriAnimator.SetBool("Ciripose2IsTicked", false);
            CiriAnimator.SetBool("Ciripose3IsTicked", false);
        }
    }
    public void CiriChangeToPose1(bool value)
    {
        if (value)
        {
            CiriAnimator.SetBool("CiriIdleIsTicked", false);
            CiriAnimator.SetBool("Ciripose1IsTicked", true);
            CiriAnimator.SetBool("Ciripose2IsTicked", false);
            CiriAnimator.SetBool("Ciripose3IsTicked", false);
        }
    }

    public void CiriChangeToPose2(bool value)
    {
        if (value)
        {
            CiriAnimator.SetBool("CiriIdleIsTicked", false);
            CiriAnimator.SetBool("Ciripose1IsTicked", false);
            CiriAnimator.SetBool("Ciripose2IsTicked", true);
            CiriAnimator.SetBool("Ciripose3IsTicked", false);
        }
    }

    public void CiriChangeToPose3(bool value)
    {
        if (value)
        {
            CiriAnimator.SetBool("CiriIdleIsTicked", false);
            CiriAnimator.SetBool("Ciripose1IsTicked", false);
            CiriAnimator.SetBool("Ciripose2IsTicked", false);
            CiriAnimator.SetBool("Ciripose3IsTicked", true);
        }
    }

    public void BeltControls(bool value)
    {
        if (value)
        {
            beltEnabled = true;
            Belt.SetActive(true);
            scabbardEnabled = true;
            Scabbard.SetActive(true);
        }
        else
        {
            beltEnabled = false;
            Belt.SetActive(false);
            scabbardEnabled = false;
            Scabbard.SetActive(false);
        }
    }
    public void ClothesControls(bool value)
    {
        if (value)
        {
            clothesEnabled = true;
            Clothes.SetActive(true);

            bodyEnabled = false;
            Body.SetActive(false);
        }
        else
        {
            clothesEnabled = false;
            Clothes.SetActive(false);

            bodyEnabled = true;
            Body.SetActive(true);
        }
    }
    public void BodyControls(bool value)
    {
        if (value)
        {
            beltEnabled = true;
            Belt.SetActive(true);
        }
        else
        {
            beltEnabled = false;
            Belt.SetActive(false);
        }
    }
    public void NecklaceControls(bool value)
    {
        if (value)
        {
            necklaceEnabled = true;
            Necklace.SetActive(true);
        }
        else
        {
            necklaceEnabled = false;
            Necklace.SetActive(false);
        }
    }
}

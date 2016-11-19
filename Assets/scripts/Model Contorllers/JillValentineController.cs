using UnityEngine;
using System.Collections;

public class JillValentineController : MonoBehaviour {

    public GameObject Hair;
    [SerializeField]
    bool hairEnabled;

    public GameObject HairBeret;
    [SerializeField]
    bool hairBeretEnabled;

    public GameObject Shirt;
    [SerializeField]
    bool shirtEnabled;

    public GameObject UpperArmor;
    [SerializeField]
    bool upperArmorEnabled;

    public GameObject Belt;
    [SerializeField]
    bool beltEnabled;

    public GameObject Gloves;
    [SerializeField]
    bool glovesEnabled;

    public GameObject Trousers;
    [SerializeField]
    bool trousersrEnabled;

    public GameObject Boots;
    [SerializeField]
    bool bootsEnabled;

    public GameObject DeaglePose1;

    public Animator JillValentineAnimator;

    void Start ()
    {
	    
	}
	
	void Update ()
    {
	    
	}

    public void JillValentineChangeToPose1(bool value)
    {
        if (value)
        {
            JillValentineAnimator.SetBool("JillValentinepose1isTicked", true);
            JillValentineAnimator.SetBool("JillValentinepose2isTicked", false);
            JillValentineAnimator.SetBool("JillValentinepose3isTicked", false);

            DeaglePose1.SetActive(true);
        }
    }

    public void JillValentineChangeToPose2(bool value)
    {
        if (value)
        {
            JillValentineAnimator.SetBool("JillValentinepose1isTicked", false);
            JillValentineAnimator.SetBool("JillValentinepose2isTicked", true);
            JillValentineAnimator.SetBool("JillValentinepose3isTicked", false);

            DeaglePose1.SetActive(false);
        }
    }

    public void JillValentineChangeToPose3(bool value)
    {
        if (value)
        {
            JillValentineAnimator.SetBool("JillValentinepose1isTicked", false);
            JillValentineAnimator.SetBool("JillValentinepose2isTicked", false);
            JillValentineAnimator.SetBool("JillValentinepose3isTicked", true);

            DeaglePose1.SetActive(false);
        }
    }

    public void BeretControls(bool value)
    {
        if (value)
        {
            hairBeretEnabled = true;
            HairBeret.SetActive(true);

            hairEnabled = false;
            Hair.SetActive(false);
        }
        else
        {
            hairBeretEnabled = false;
            HairBeret.SetActive(false);

            hairEnabled = true;
            Hair.SetActive(true);
        }
    }

    public void GearControls(bool value)
    {
        if (value)
        {
            upperArmorEnabled = true;
            UpperArmor.SetActive(true);
        }
        else
        {
            upperArmorEnabled = false;
            UpperArmor.SetActive(false);
        }
    }
    public void ShirtControls(bool value)
    {
        if (value)
        {
            shirtEnabled = true;
            Shirt.SetActive(true);
        }
        else
        {
            shirtEnabled = false;
            Shirt.SetActive(false);
        }
    }
    public void GlovesControls(bool value)
    {
        if (value)
        {
            glovesEnabled = true;
            Gloves.SetActive(true);
        }
        else
        {
            glovesEnabled = false;
            Gloves.SetActive(false);
        }
    }
    public void BeltControls(bool value)
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
    public void PantsControls(bool value)
    {
        if (value)
        {
            bootsEnabled = true;
            Boots.SetActive(true);
        }
        else
        {
            bootsEnabled = false;
            Boots.SetActive(false);
        }
    }
    public void BootsControls(bool value)
    {
        if (value)
        {
            bootsEnabled = true;
            Boots.SetActive(true);
        }
        else
        {
            bootsEnabled = false;
            Boots.SetActive(false);
        }
    }
}

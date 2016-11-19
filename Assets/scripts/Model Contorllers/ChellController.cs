using UnityEngine;
using System.Collections;

public class ChellController : MonoBehaviour {

    public GameObject TankTop;
    [SerializeField]
    bool tankTopEnabled;

    public GameObject Pants;
    [SerializeField]
    bool pantsEnabled;

    public GameObject Boots;
    [SerializeField]
    bool bootsEnabled;

    public GameObject Feet;
    [SerializeField]
    bool feetEnabled;

    public GameObject Apparatus;
    [SerializeField]
    bool apparatusEnabled;

    public Animator ChellAnimator;

    public GameObject PortalGun;

    void Start ()
    {
        TankTop.SetActive(tankTopEnabled);
        Pants.SetActive(pantsEnabled);
        Boots.SetActive(bootsEnabled);
        Apparatus.SetActive(apparatusEnabled);
	}

    public void ChellChangeToPose1(bool value)
    {
        if(value)
        {
            ChellAnimator.SetBool("Chellpose1isTicked", true);
            ChellAnimator.SetBool("Chellpose2isTicked", false);
            ChellAnimator.SetBool("Chellpose3isTicked", false);

            PortalGun.SetActive(true);
        }
    }
    public void ChellChangeToPose2(bool value)
    {
        if (value)
        {
            ChellAnimator.SetBool("Chellpose1isTicked", false);
            ChellAnimator.SetBool("Chellpose2isTicked", true);
            ChellAnimator.SetBool("Chellpose3isTicked", false);

            PortalGun.SetActive(false);
        }
    }
    public void ChellChangeToPose3(bool value)
    {
        if (value)
        {
            ChellAnimator.SetBool("Chellpose1isTicked", false);
            ChellAnimator.SetBool("Chellpose2isTicked", false);
            ChellAnimator.SetBool("Chellpose3isTicked", true);

            PortalGun.SetActive(false);
        }
    }

    /*Toggle controls for UI*/
    public void TankTopControls(bool value)
    {
        if (value)
        {
            tankTopEnabled = true;
            TankTop.SetActive(true);
        }
        else
        {
            tankTopEnabled = false;
            TankTop.SetActive(false);
        }
    }

    public void PantsControls(bool value)
    {
        if(value)
        {
            pantsEnabled = true;
            Pants.SetActive(true);
        }
        else
        {
            pantsEnabled = false;
            Pants.SetActive(false);
        }
    }

    public void BootsControls(bool value)
    {
        if (value)
        {
            bootsEnabled = true;
            Boots.SetActive(true);

            feetEnabled = false;
            Feet.SetActive(false);
        }
        else
        {
            bootsEnabled = false;
            Boots.SetActive(false);

            feetEnabled = true;
            Feet.SetActive(true);
        }
    }

    public void ApparatusControls(bool value)
    {
        if (value)
        {
            apparatusEnabled = true;
            Apparatus.SetActive(true);
        }
        else
        {
            apparatusEnabled = false;
            Apparatus.SetActive(false);
        }
    }
}

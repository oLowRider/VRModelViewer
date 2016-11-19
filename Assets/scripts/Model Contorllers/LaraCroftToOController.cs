using UnityEngine;
using System.Collections;

public class LaraCroftToOController : MonoBehaviour {

    public GameObject Base;
    public GameObject Face1;
    public GameObject Hair;
    public GameObject Braid;
    public GameObject NormalShirt;
    public GameObject NormalShorts;
    public GameObject UnderTop;
    public GameObject UnderPants;
    public GameObject TR2013Top;
    public GameObject TR2013Pants;
    public GameObject Backpack;
    public GameObject Gloves;
    public GameObject Boots;
    public GameObject Holster;

    public GameObject LaraLGunPose1, LaraRGunPose1, LaraLGunPose3, LaraRGunPose3;

    public Animator LaraToOAnimator;

    void Start ()
    {
        Base.SetActive(true);
        Face1.SetActive(true);
        Hair.SetActive(true);
        Braid.SetActive(true);
        NormalShirt.SetActive(true);
        NormalShorts.SetActive(true);
        UnderTop.SetActive(false);
        UnderPants.SetActive(false);
        TR2013Top.SetActive(false);
        TR2013Pants.SetActive(false);
        Backpack.SetActive(true);
        Gloves.SetActive(true);
        Boots.SetActive(true);
        Holster.SetActive(true);

        LaraLGunPose1.SetActive(true);
        LaraRGunPose1.SetActive(true);
        LaraLGunPose3.SetActive(false);
        LaraRGunPose3.SetActive(false);
	}
	
	void FixedUpdate ()
    {
	
	}

    public void LaraToOChangeToPose1(bool value)
    {
        if (value)
        {
            LaraToOAnimator.SetBool("LaraToOpose1isTicked", true);
            LaraToOAnimator.SetBool("LaraToOpose2isTicked", false);
            LaraToOAnimator.SetBool("LaraToOpose3isTicked", false);

            LaraLGunPose1.SetActive(true);
            LaraRGunPose1.SetActive(true);
            LaraLGunPose3.SetActive(false);
            LaraRGunPose3.SetActive(false);
        }
    }
    public void LaraToOChangeToPose2(bool value)
    {
        if (value)
        {
            LaraToOAnimator.SetBool("LaraToOpose1isTicked", false);
            LaraToOAnimator.SetBool("LaraToOpose2isTicked", true);
            LaraToOAnimator.SetBool("LaraToOpose3isTicked", false);

            LaraLGunPose1.SetActive(false);
            LaraRGunPose1.SetActive(false);
            LaraLGunPose3.SetActive(false);
            LaraRGunPose3.SetActive(false);
        }
    }
    public void LaraToOChangeToPose3(bool value)
    {
        if (value)
        {
            LaraToOAnimator.SetBool("LaraToOpose1isTicked", false);
            LaraToOAnimator.SetBool("LaraToOpose2isTicked", false);
            LaraToOAnimator.SetBool("LaraToOpose3isTicked", true);

            LaraLGunPose1.SetActive(false);
            LaraRGunPose1.SetActive(false);
            LaraLGunPose3.SetActive(true);
            LaraRGunPose3.SetActive(true);
        }
    }

    public void NormalShirtControls(bool value)
    {
        if (value)
        {
            NormalShirt.SetActive(true);
            UnderTop.SetActive(false);
            TR2013Top.SetActive(false);
        }
        else
        {
            NormalShirt.SetActive(false);
        }
    }
    public void NormalShortsControls(bool value)
    {
        if (value)
        {
            NormalShorts.SetActive(true);
            UnderPants.SetActive(false);
            TR2013Pants.SetActive(false);
        }
        else
        {
            NormalShorts.SetActive(false);
        }
    }
    public void UnderTopControls(bool value)
    {
        if (value)
        {
            NormalShirt.SetActive(false);
            UnderTop.SetActive(true);
            TR2013Top.SetActive(false);
        }
        else
        {
            UnderTop.SetActive(false);
        }
    }
    public void UnderPantsControls(bool value)
    {
        if (value)
        {
            NormalShorts.SetActive(false);
            UnderPants.SetActive(true);
            TR2013Pants.SetActive(false);
        }
        else
        {
            UnderPants.SetActive(false);
        }
    }
    public void TR2013TopControls(bool value)
    {
        if (value)
        {
            NormalShirt.SetActive(false);
            UnderTop.SetActive(false);
            TR2013Top.SetActive(true);
        }
        else
        {
            TR2013Top.SetActive(false);
        }
    }
    public void TR2013PantsControls(bool value)
    {
        if (value)
        {
            NormalShorts.SetActive(false);
            UnderPants.SetActive(false);
            TR2013Pants.SetActive(true);
        }
        else
        {
            TR2013Pants.SetActive(false);
        }
    }
    public void NudeTopControls(bool value)
    {
        if (value)
        {
            NormalShirt.SetActive(false);
            UnderTop.SetActive(false);
            TR2013Top.SetActive(false);
        }
        else
        {
            //TR2013Top.SetActive(false);
        }
    }
    public void NudePantsControls(bool value)
    {
        if (value)
        {
            NormalShorts.SetActive(false);
            UnderPants.SetActive(false);
            TR2013Pants.SetActive(false);
        }
        else
        {
            //TR2013Pants.SetActive(false);
        }
    }
    public void BootsControls(bool value)
    {
        if (value)
        {
            Boots.SetActive(true);
        }
        else
        {
            Boots.SetActive(false);
        }
    }
    public void BackpackControls(bool value)
    {
        if (value)
        {
            Backpack.SetActive(true);
        }
        else
        {
            Backpack.SetActive(false);
        }
    }
    public void HolsterControls(bool value)
    {
        if (value)
        {
            Holster.SetActive(true);
        }
        else
        {
            Holster.SetActive(false);
        }
    }
    public void GlovesControls(bool value)
    {
        if (value)
        {
            Gloves.SetActive(true);
        }
        else
        {
            Gloves.SetActive(false);
        }
    }
}

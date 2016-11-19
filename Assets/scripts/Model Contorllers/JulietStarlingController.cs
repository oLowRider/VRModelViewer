using UnityEngine;
using System.Collections;

public class JulietStarlingController : MonoBehaviour {

    public GameObject Juliet;
    public GameObject SweatBands;
    public GameObject Leggings;
    public GameObject Panties;
    public GameObject Skirt;
    public GameObject Bra;

    public GameObject ChainsawPose2;

    public Animator JulietAnimator;

    void Start ()
    {
        Juliet.SetActive(true);
        SweatBands.SetActive(true);
        Leggings.SetActive(true);
        Panties.SetActive(true);
        Skirt.SetActive(true);
        Bra.SetActive(true);

        ChainsawPose2.SetActive(true);
	}
	
	void FixedUpdate ()
    {
	
	}

    public void JulietHeadLookToggle(bool value)
    {
        //this.GetComponent<HeadLookController>().enabled = value;
        if (value)
        {
            this.GetComponent<HeadLookController>().enabled = true;
            GameObject.Find("Camera (eye)").GetComponent<CursorHit>().headLookEnabled = false;
        }
        else
        {
            GameObject.Find("Camera (eye)").GetComponent<CursorHit>().headLookEnabled = false;
            this.GetComponent<HeadLookController>().enabled = false;
        }
    }

    public void JulietChangeToPose1(bool value)
    {
        if (value)
        {
            JulietAnimator.SetBool("Julietpose1isTicked", true);
            JulietAnimator.SetBool("Julietpose2isTicked", false);
            JulietAnimator.SetBool("Julietpose3isTicked", false);

            ChainsawPose2.SetActive(true);
        }
    }
    public void JulietChangeToPose2(bool value)
    {
        if (value)
        {
            JulietAnimator.SetBool("Julietpose1isTicked", false);
            JulietAnimator.SetBool("Julietpose2isTicked", true);
            JulietAnimator.SetBool("Julietpose3isTicked", false);

            ChainsawPose2.SetActive(false);
        }
    }
    public void JulietChangeToPose3(bool value)
    {
        if (value)
        {
            JulietAnimator.SetBool("Julietpose1isTicked", false);
            JulietAnimator.SetBool("Julietpose2isTicked", false);
            JulietAnimator.SetBool("Julietpose3isTicked", true);

            ChainsawPose2.SetActive(false);
        }
    }

    public void BraControls(bool value)
    {
        if (value)
        {
            Bra.SetActive(true);
        }
        else
        {
            Bra.SetActive(false);
        }
    }
    public void SkirtControls(bool value)
    {
        if (value)
        {
            Skirt.SetActive(true);
        }
        else
        {
            Skirt.SetActive(false);
        }
    }
    public void LeggingsControls(bool value)
    {
        if (value)
        {
            Leggings.SetActive(true);
        }
        else
        {
            Leggings.SetActive(false);
        }
    }
    public void PantiesControls(bool value)
    {
        if (value)
        {
            Panties.SetActive(true);
        }
        else
        {
            Panties.SetActive(false);
        }
    }
    public void BandsControls(bool value)
    {
        if (value)
        {
            SweatBands.SetActive(true);
        }
        else
        {
            SweatBands.SetActive(false);
        }
    }
}

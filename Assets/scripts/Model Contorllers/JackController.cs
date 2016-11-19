using UnityEngine;
using System.Collections;

public class JackController : MonoBehaviour
{
    public GameObject JackReference;
    public GameObject JackNude;
    public GameObject JackHands;
    public GameObject[] Piercings;
    public GameObject Sunglasses;
    public GameObject Hat;
    public GameObject Gloves;
    public GameObject Straps;
    public GameObject Jacket;
    public GameObject PopIdolTop;
    public GameObject PopIdolSkirt;

    public Animator JackAnimator;

    void Start()
    {

    }

    void FixedUpdate()
    {

    }


    public void JackChangeToPose1(bool value)
    {
        if (value)
        {
            JackAnimator.SetBool("Jackpose1isTicked", true);
            JackAnimator.SetBool("Jackpose2isTicked", false);
            JackAnimator.SetBool("Jackpose3isTicked", false);
        }
    }
    public void JackChangeToPose2(bool value)
    {
        if (value)
        {
            JackAnimator.SetBool("Jackpose1isTicked", false);
            JackAnimator.SetBool("Jackpose2isTicked", true);
            JackAnimator.SetBool("Jackpose3isTicked", false);
        }
    }
    public void JackChangeToPose3(bool value)
    {
        if (value)
        {
            JackAnimator.SetBool("Jackpose1isTicked", false);
            JackAnimator.SetBool("Jackpose2isTicked", false);
            JackAnimator.SetBool("Jackpose3isTicked", true);
        }
    }

    public void PiercingControls(bool value)
    {
        if (value)
        {
            foreach (GameObject obj in Piercings)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject obj in Piercings)
            {
                obj.SetActive(false);
            }
        }
    }
    public void SunglassesControls(bool value)
    {
        if (value)
        {
            Sunglasses.SetActive(true);
        }
        else
        {
            Sunglasses.SetActive(false);
        }
    }
    public void HatControls(bool value)
    {
        if (value)
        {
            Hat.SetActive(true);
        }
        else
        {
            Hat.SetActive(false);
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
    public void StrapsControls(bool value)
    {
        if (value)
        {
            Straps.SetActive(true);
            Jacket.SetActive(false);
            PopIdolTop.SetActive(false);
        }
        else
        {
            Straps.SetActive(false);
        }
    }
    public void JacketControls(bool value)
    {
        if (value)
        {
            Straps.SetActive(false);
            Jacket.SetActive(true);
            PopIdolTop.SetActive(false);
        }
        else
        {
            Jacket.SetActive(false);
        }
    }
    public void PopIdolControls(bool value)
    {
        if (value)
        {
            Straps.SetActive(false);
            Jacket.SetActive(false);
            PopIdolTop.SetActive(true);
        }
        else
        {
            PopIdolTop.SetActive(false);
        }
    }
    public void PopIdolSkirtControls(bool value)
    {
        if (value)
        {
            PopIdolSkirt.SetActive(true);
        }
        else
        {
            PopIdolSkirt.SetActive(false);
        }
    }
    public void NudeControls(bool value)
    {
        if (value)
        {
            PopIdolSkirt.SetActive(false);
        }
        else
        {
            PopIdolSkirt.SetActive(false);
        }
    }
    public void NudeTopControls(bool value)
    {
        if (value)
        {
            Straps.SetActive(false);
            Jacket.SetActive(false);
            PopIdolTop.SetActive(false);
        }
        else
        {
            
        }
    }
}

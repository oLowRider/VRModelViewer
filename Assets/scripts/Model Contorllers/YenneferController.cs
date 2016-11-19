using UnityEngine;
using System.Collections;

public class YenneferController : MonoBehaviour {

    public GameObject Collar;
    [SerializeField]
    bool collarEnabled;

    public GameObject FurCollar;
    [SerializeField]
    bool furCollarEnabled;

    public GameObject Clothes;
    [SerializeField]
    bool clothesEnabled;

    public GameObject NudeBody;
    [SerializeField]
    bool nudeBodyEnabled;

    public GameObject Hair;
    [SerializeField]
    bool hairEnabled;

    public GameObject Stool;

    public Animator YenneferAnimator;

	void Start ()
    {
        Collar.SetActive(true);
        FurCollar.SetActive(true);
        Hair.SetActive(false);
        Clothes.SetActive(true);
        NudeBody.SetActive(false);
	}

    public void YenneferChangeToPose1(bool value)
    {
        if (value)
        {
            YenneferAnimator.SetBool("Yenneferpose1isTicked", true);
            YenneferAnimator.SetBool("Yenneferpose2isTicked", false);
            YenneferAnimator.SetBool("Yenneferpose3isTicked", false);

            Stool.SetActive(true);
        }
    }
    public void YenneferChangeToPose2(bool value)
    {
        if (value)
        {
            YenneferAnimator.SetBool("Yenneferpose1isTicked", false);
            YenneferAnimator.SetBool("Yenneferpose2isTicked", true);
            YenneferAnimator.SetBool("Yenneferpose3isTicked", false);

            Stool.SetActive(false);
        }
    }
    public void YenneferChangeToPose3(bool value)
    {
        if (value)
        {
            YenneferAnimator.SetBool("Yenneferpose1isTicked", false);
            YenneferAnimator.SetBool("Yenneferpose2isTicked", false);
            YenneferAnimator.SetBool("Yenneferpose3isTicked", true);

            Stool.SetActive(false);
        }
    }

    /*Toggle controls for UI*/
    public void CollarControls(bool value)
    {
        if (value)
        {
            collarEnabled = true;
            Collar.SetActive(true);
        }
        else
        {
            collarEnabled = false;
            Collar.SetActive(false);
        }
    }

    public void FurCollarControls(bool value)
    {
        if (value)
        {
            furCollarEnabled = true;
            FurCollar.SetActive(true);

            hairEnabled = false;
            Hair.SetActive(false);
        }
        else
        {
            furCollarEnabled = false;
            FurCollar.SetActive(false);

            hairEnabled = true;
            Hair.SetActive(true);
        }
    }

    public void ClothesControls(bool value)
    {
        if (value)
        {
            clothesEnabled = true;
            Clothes.SetActive(true);

            nudeBodyEnabled = false;
            NudeBody.SetActive(false);
        }
        else
        {
            clothesEnabled = false;
            Clothes.SetActive(false);

            nudeBodyEnabled = true;
            NudeBody.SetActive(true);
        }
    }
}

using UnityEngine;
using System.Collections;

public class HarleyQuinnController : MonoBehaviour {

    public GameObject ArmGear;
    [SerializeField]
    bool armGearEnabled;

    public GameObject Shoulders;
    [SerializeField]
    bool shouldersEnabled;

    public GameObject Boots;
    [SerializeField]
    bool bootsEnabled;

    public GameObject Chest;
    [SerializeField]
    bool chestEnabled;

    public GameObject Leggings;
    [SerializeField]
    bool leggingsEnabled;

    public GameObject Skirt;
    [SerializeField]
    bool skirtEnabled;

    public GameObject HarleyBatPose1;
    public GameObject HarleyBatPose2;

    public Animator HarleyQuinnAnimator;

    void Start()
    {
        ArmGear.SetActive(true);
        Shoulders.SetActive(true);
        Boots.SetActive(true);
        Chest.SetActive(true);
        Leggings.SetActive(true);
        Skirt.SetActive(true);

        HarleyBatPose1.SetActive(true);
    }

    public void HarleyChangeToPose1(bool value)
    {
        if (value)
        {
            HarleyQuinnAnimator.SetBool("Harleypose1isTicked", true);
            HarleyQuinnAnimator.SetBool("Harleypose2isTicked", false);
            HarleyQuinnAnimator.SetBool("Harleypose3isTicked", false);

            HarleyBatPose1.SetActive(true);
            HarleyBatPose2.SetActive(false);
        }
    }
    public void HarleyChangeToPose2(bool value)
    {
        if (value)
        {
            HarleyQuinnAnimator.SetBool("Harleypose1isTicked", false);
            HarleyQuinnAnimator.SetBool("Harleypose2isTicked", true);
            HarleyQuinnAnimator.SetBool("Harleypose3isTicked", false);

            HarleyBatPose1.SetActive(false);
            HarleyBatPose2.SetActive(true);
        }
    }
    public void HarleyChangeToPose3(bool value)
    {
        if (value)
        {
            HarleyQuinnAnimator.SetBool("Harleypose1isTicked", false);
            HarleyQuinnAnimator.SetBool("Harleypose2isTicked", false);
            HarleyQuinnAnimator.SetBool("Harleypose3isTicked", true);

            HarleyBatPose1.SetActive(false);
            HarleyBatPose2.SetActive(false);
        }
    }

    public void ArmsControls(bool value)
    {
        if (value)
        {
            armGearEnabled = true;
            ArmGear.SetActive(true);
        }
        else
        {
            armGearEnabled = false;
            ArmGear.SetActive(false);
        }
    }

    public void ShoulderControls(bool value)
    {
        if(value)
        {
            shouldersEnabled = true;
            Shoulders.SetActive(true);
        }
        else
        {
            shouldersEnabled = false;
            Shoulders.SetActive(false);
        }
    }
    public void ChestControls(bool value)
    {
        if (value)
        {
            chestEnabled = true;
            Chest.SetActive(true);
        }
        else
        {
            chestEnabled = false;
            Chest.SetActive(false);
        }
    }
    public void SkirtControls(bool value)
    {
        if (value)
        {
            skirtEnabled = true;
            Skirt.SetActive(true);
        }
        else
        {
            skirtEnabled = false;
            Skirt.SetActive(false);
        }
    }
    public void LeggingsControls(bool value)
    {
        if (value)
        {
            leggingsEnabled = true;
            Leggings.SetActive(true);
        }
        else
        {
            leggingsEnabled = false;
            Leggings.SetActive(false);
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

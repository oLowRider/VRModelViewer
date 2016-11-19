using UnityEngine;
using System.Collections;

public class TracerController : MonoBehaviour {

    public GameObject ArmGear;
    [SerializeField]
    bool armGearEnabled;

    public GameObject BodyArms;
    [SerializeField]
    bool bodyArmsEnabled;

    public GameObject BodyLegs;
    [SerializeField]
    bool bodyLegsEnabled;

    public GameObject Earring;
    [SerializeField]
    bool earringEnabled;

    public GameObject GearBack;
    [SerializeField]
    bool gearBackEnabled;

    public GameObject GearFront;
    [SerializeField]
    bool gearFrontEnabled;

    public GameObject Gloves;
    [SerializeField]
    bool glovesEnabled;

    public GameObject HarnessLower;
    [SerializeField]
    bool harnessLowerEnabled;

    public GameObject HarnessUpper;
    [SerializeField]
    bool harnessUpperEnabled;

    public GameObject Jacket;
    [SerializeField]
    bool jacketEnabled;

    public GameObject Leggings;
    [SerializeField]
    bool leggingsEnabled;

    public GameObject Reference;
    [SerializeField]
    bool referenceEnabled;

    public GameObject Shoes;
    [SerializeField]
    bool shoesEnabled;

    public GameObject Visor;
    [SerializeField]
    bool visorEnabled;

    public GameObject[] TracerEyes;

    public GameObject TracerGunLPose1;
    public GameObject TracerGunRPose1;
    public GameObject TracerGunLPose2;
    public GameObject TracerGunRPose2;
    public GameObject TracerGunLPose3;
    public GameObject TracerGunRPose3;

    public SkinnedMeshRenderer TracerBlendShapes;
    public Animator TracerAnimator;

    public AudioClip[] StartClips, RandomClips, EndClips;
    public AudioSource tracerAudioSource;

    float counter = 0;

    void Start ()
    {
        ArmGear.SetActive(true);
        BodyArms.SetActive(false);
        BodyLegs.SetActive(false);
        Earring.SetActive(true);
        GearBack.SetActive(true);
        GearFront.SetActive(true);
        Gloves.SetActive(true);
        HarnessUpper.SetActive(true);
        HarnessLower.SetActive(true);
        Jacket.SetActive(true);
        Leggings.SetActive(true);
        Reference.SetActive(true);
        Shoes.SetActive(true);
        Visor.SetActive(true);

        TracerGunLPose1.SetActive(true);
        TracerGunRPose1.SetActive(true);

        TracerGunLPose2.SetActive(false);
        TracerGunRPose2.SetActive(false);

        TracerGunLPose3.SetActive(false);
        TracerGunRPose3.SetActive(false);
    }

    void FixedUpdate()
    {
        int randomClips = Random.Range(0, RandomClips.Length);
        if (!tracerAudioSource.isPlaying)
        {            
            counter = counter + 1;
            if(counter > 5400)
            {
                tracerAudioSource.PlayOneShot(RandomClips[randomClips]);
                counter = 0;
            }
        }
    }

    void LateUpdate()
    {
        if (Jacket.activeSelf)
        {
            TracerBlendShapes.SetBlendShapeWeight(23, 100);
        }
        else
        {
            TracerBlendShapes.SetBlendShapeWeight(23, 0);
        }

        if (Leggings.activeSelf)
        {
            TracerBlendShapes.SetBlendShapeWeight(21, 100);
            TracerBlendShapes.SetBlendShapeWeight(22, 100);
        }
        else
        {
            TracerBlendShapes.SetBlendShapeWeight(21, 0);
            TracerBlendShapes.SetBlendShapeWeight(22, 0);
        }
    }

    public void TracerChangeToPose1(bool value)
    {
        if (value)
        {
            TracerAnimator.SetBool("Tracerpose1isTicked", true);
            TracerAnimator.SetBool("Tracerpose2isTicked", false);
            TracerAnimator.SetBool("Tracerpose3isTicked", false);

            TracerGunLPose1.SetActive(true);
            TracerGunRPose1.SetActive(true);

            TracerGunLPose2.SetActive(false);
            TracerGunRPose2.SetActive(false);

            TracerGunLPose3.SetActive(false);
            TracerGunRPose3.SetActive(false);
            this.GetComponent<HeadLookController>().enabled = true;
        
        }
    }
    public void TracerChangeToPose2(bool value)
    {
        if (value)
        {
            TracerAnimator.SetBool("Tracerpose1isTicked", false);
            TracerAnimator.SetBool("Tracerpose2isTicked", true);
            TracerAnimator.SetBool("Tracerpose3isTicked", false);

            TracerGunLPose1.SetActive(false);
            TracerGunRPose1.SetActive(false);

            TracerGunLPose2.SetActive(true);
            TracerGunRPose2.SetActive(true);

            TracerGunLPose3.SetActive(false);
            TracerGunRPose3.SetActive(false);
            this.GetComponent<HeadLookController>().enabled = true;

        }
    }
    public void TracerChangeToPose3(bool value)
    {
        if (value)
        {
            TracerAnimator.SetBool("Tracerpose1isTicked", false);
            TracerAnimator.SetBool("Tracerpose2isTicked", false);
            TracerAnimator.SetBool("Tracerpose3isTicked", true);

            TracerGunLPose1.SetActive(false);
            TracerGunRPose1.SetActive(false);

            TracerGunLPose2.SetActive(false);
            TracerGunRPose2.SetActive(false);

            TracerGunLPose3.SetActive(true);
            TracerGunRPose3.SetActive(true);

            this.GetComponent<HeadLookController>().enabled = false;

        }
    }
    public void GoToAnim(bool value)
    {
        if (value)
        {
            TracerAnimator.SetBool("Tracerpose1isTicked", false);
            TracerAnimator.SetBool("Tracerpose2isTicked", false);
            TracerAnimator.SetBool("Tracerpose3isTicked", false);
            TracerAnimator.SetBool("GoToAnim", true);

            TracerGunLPose1.SetActive(false);
            TracerGunRPose1.SetActive(false);

            TracerGunLPose2.SetActive(false);
            TracerGunRPose2.SetActive(false);

            TracerGunLPose3.SetActive(false);
            TracerGunRPose3.SetActive(false);
        }
    }

    /*Toggle controls for UI*/
    public void HarnessControls(bool value)
    {
        if (value)
        {
            harnessUpperEnabled = true;
            HarnessUpper.SetActive(true);
            harnessLowerEnabled = true;
            HarnessLower.SetActive(true);
        }
        else
        {
            harnessUpperEnabled = false;
            HarnessUpper.SetActive(false);
            harnessLowerEnabled = false;
            HarnessLower.SetActive(false);
        }
    }

    public void GearControls(bool value)
    {
        if (value)
        {
            gearBackEnabled = true;
            GearBack.SetActive(true);
            gearFrontEnabled = true;
            GearFront.SetActive(true);
            armGearEnabled = true;
            ArmGear.SetActive(true);
        }
        else
        {
            gearBackEnabled = false;
            GearBack.SetActive(false);
            gearFrontEnabled = false;
            GearFront.SetActive(false);
            armGearEnabled = false;
            ArmGear.SetActive(false);
        }
    }
    public void VisorControls(bool value)
    {
        if (value)
        {
            visorEnabled = true;
            Visor.SetActive(true);
            
        }
        else
        {
            visorEnabled = false;
            Visor.SetActive(false);
        }
    }
    public void JacketControls(bool value)
    {
        if (value)
        {
            jacketEnabled = true;
            Jacket.SetActive(true);
            glovesEnabled = true;
            Gloves.SetActive(true);

            BodyArms.SetActive(false);
            bodyArmsEnabled = false;
        }
        else
        {
            jacketEnabled = false;
            Jacket.SetActive(false);
            glovesEnabled = false;
            Gloves.SetActive(false);

            BodyArms.SetActive(true);
            bodyArmsEnabled = true;
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
    public void ShoesControls(bool value)
    {
        if (value)
        {
            shoesEnabled = true;
            Shoes.SetActive(true);

            bodyLegsEnabled = false;
            BodyLegs.SetActive(false);
        }
        else
        {
            shoesEnabled = false;
            Shoes.SetActive(false);

            bodyLegsEnabled = true;
            BodyLegs.SetActive(true);
        }
    }

    public void OnActivate()
    {
        if (tracerAudioSource.isPlaying) return;

        int randomStart = Random.Range(0, StartClips.Length);
        tracerAudioSource.PlayOneShot(StartClips[randomStart]);
    }

    public void OnDeactivate()
    {
        if (tracerAudioSource.isPlaying) return;

        int randomEnd = Random.Range(0, EndClips.Length);
        tracerAudioSource.PlayOneShot(EndClips[randomEnd]);
    }

    public void AddToScale()
    {

    }
}

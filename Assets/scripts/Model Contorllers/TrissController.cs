using UnityEngine;
using System.Collections;

public class TrissController : MonoBehaviour {

    public GameObject Dress;
    [SerializeField]
    bool dressEnabled;

    public GameObject Regular;
    [SerializeField]
    bool regularEnabled;

    public GameObject Lingerie;
    [SerializeField]
    bool lingerieEnabled;

    public GameObject Nude;
    [SerializeField]
    bool nudeEnabled;

    public GameObject Necklace;
    [SerializeField]
    bool necklaceEnabled;

    public GameObject Earrings;
    [SerializeField]
    bool earringsEnabled;

    public GameObject TrissHead;
    [SerializeField]
    bool trissHeadEnabled;

    public GameObject Hair;
    [SerializeField]
    bool hairEnabled;

    public SkinnedMeshRenderer TrissBlendShapes;
    public Animator TrissAnimator;

    public AudioClip[] StartClips, RandomClips, EndClips;
    public AudioSource TrissAudioSource;

    void Start ()
    {
        TrissHead.SetActive(true);
        Hair.SetActive(true);
        Regular.SetActive(true);
        Dress.SetActive(false);
        Lingerie.SetActive(false);
        Nude.SetActive(false);
        Necklace.SetActive(true);
        Earrings.SetActive(true);
    }
	
	void LateUpdate ()
    {
        TrissBlendShapes.SetBlendShapeWeight(0, 20);
        TrissBlendShapes.SetBlendShapeWeight(1, 20);
    }

    public void TrissChangeToPose1(bool value)
    {
        if (value)
        {
            TrissAnimator.SetBool("Trisspose1isTicked", true);
            TrissAnimator.SetBool("Trisspose2isTicked", false);
            TrissAnimator.SetBool("Trisspose3isTicked", false);
        }
    }
    public void TrissChangeToPose2(bool value)
    {
        if (value)
        {
            TrissAnimator.SetBool("Trisspose1isTicked", false);
            TrissAnimator.SetBool("Trisspose2isTicked", true);
            TrissAnimator.SetBool("Trisspose3isTicked", false);
        }
    }
    public void TrissChangeToPose3(bool value)
    {
        if (value)
        {
            TrissAnimator.SetBool("Trisspose1isTicked", false);
            TrissAnimator.SetBool("Trisspose2isTicked", false);
            TrissAnimator.SetBool("Trisspose3isTicked", true);
        }
    }
    public void DressControls(bool value)
    {
        if (value)
        {
            dressEnabled = true;
            Dress.SetActive(true);
            regularEnabled = false;
            Regular.SetActive(false);
            lingerieEnabled = false;
            Lingerie.SetActive(false);
            nudeEnabled = false;
            Nude.SetActive(false);
        }
        else
        {
            dressEnabled = false;
            Dress.SetActive(false);
        }
    }
    public void RegularControls(bool value)
    {
        if (value)
        {
            dressEnabled = false;
            Dress.SetActive(false);
            regularEnabled = true;
            Regular.SetActive(true);
            lingerieEnabled = false;
            Lingerie.SetActive(false);
            nudeEnabled = false;
            Nude.SetActive(false);
        }    
        else
        {
            regularEnabled = false;
            Regular.SetActive(false);
        }
    }
    public void LingerieControls(bool value)
    {
        if (value)
        {
            dressEnabled = false;
            Dress.SetActive(false);
            regularEnabled = false;
            Regular.SetActive(false);
            lingerieEnabled = true;
            Lingerie.SetActive(true);
            nudeEnabled = false;
            Nude.SetActive(false);
        }
        else
        {
            lingerieEnabled = false;
            Lingerie.SetActive(false);
        }
    }
    public void NudeControls(bool value)
    {
        if (value)
        {
            dressEnabled = false;
            Dress.SetActive(false);
            regularEnabled = false;
            Regular.SetActive(false);
            lingerieEnabled = false;
            Lingerie.SetActive(false);
            nudeEnabled = true;
            Nude.SetActive(true);
        }
        else
        {
            nudeEnabled = false;
            Nude.SetActive(false);
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

    public void EarringsControls(bool value)
    {
        if (value)
        {
            earringsEnabled = true;
            Earrings.SetActive(true);
        }
        else
        {
            earringsEnabled = false;
            Earrings.SetActive(false);
        }
    }
    public void TrissHLCToggle(bool ticked)
    {
        if(ticked)
        {
            this.gameObject.GetComponent<HeadLookController>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<HeadLookController>().enabled = false;
        }
        //Works but need to store original rotations as disabling doesnt restore them        
    }
}

using UnityEngine;
using System.Collections;

public class NidaleeController : MonoBehaviour {

    public GameObject ArmApp;
    [SerializeField]
    bool armAppEnabled;

    public GameObject Kilt;
    [SerializeField]
    bool kiltEnabled;

    public GameObject Bra;
    [SerializeField]
    bool braEnabled;

    public GameObject Belt;
    [SerializeField]
    bool beltEnabled;

    public GameObject Boots;
    [SerializeField]
    bool bootsEnabled;

    public GameObject Bracers;
    [SerializeField]
    bool bracersEnabled;

    public GameObject Earrings;
    [SerializeField]
    bool earringsEnabled;

    public GameObject Necklace;
    [SerializeField]
    bool necklaceEnabled;

    public GameObject Spear;
    [SerializeField]
    bool SpearEnabled;

    public SkinnedMeshRenderer NidaleeBlendShapes;
    public Animator NidaleeAnimator;

    public AudioClip[] StartClips, RandomClips, EndClips;
    public AudioSource nidaleeAudioSource;

    float counter = 0;

    void Start ()
    {
        ArmApp.SetActive(true);
        Kilt.SetActive(true);
        Bra.SetActive(true);
        Belt.SetActive(true);
        Boots.SetActive(true);
        Bracers.SetActive(true);
        Earrings.SetActive(true);
        Necklace.SetActive(true);

        Spear.SetActive(true); //Change once made poses.
    }
	
	void FixedUpdate ()
    {
        int randomClips = Random.Range(0, RandomClips.Length);
        if (!nidaleeAudioSource.isPlaying)
        {
            counter = counter + 1;
            if (counter > 5400)
            {
                nidaleeAudioSource.PlayOneShot(RandomClips[randomClips]);
                counter = 0;
            }
        }
    }

    public void NidaleeChangeToPose1(bool value)
    {
        if (value)
        {
            NidaleeAnimator.SetBool("Nidaleepose1isTicked", true);
            NidaleeAnimator.SetBool("Nidaleepose2isTicked", false);
            NidaleeAnimator.SetBool("Nidaleepose3isTicked", false);
        }
    }

    public void NidaleeChangeToPose2(bool value)
    {
        if (value)
        {
            NidaleeAnimator.SetBool("Nidaleepose1isTicked", false);
            NidaleeAnimator.SetBool("Nidaleepose2isTicked", true);
            NidaleeAnimator.SetBool("Nidaleepose3isTicked", false);
        }
    }

    public void NidaleeChangeToPose3(bool value)
    {
        if (value)
        {
            NidaleeAnimator.SetBool("Nidaleepose1isTicked", false);
            NidaleeAnimator.SetBool("Nidaleepose2isTicked", false);
            NidaleeAnimator.SetBool("Nidaleepose3isTicked", true);
        }
    }

    public void ArmsControls(bool value)
    {
        if (value)
        {
            ArmApp.SetActive(true);
            Bracers.SetActive(true);
        }
        else
        {
            ArmApp.SetActive(false);
            Bracers.SetActive(false);
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
    public void EarringsControls(bool value)
    {
        if (value)
        {
            Earrings.SetActive(true);
        }
        else
        {
            Earrings.SetActive(false);
        }
    }
    public void NecklaceControls(bool value)
    {
        if (value)
        {
            Necklace.SetActive(true);
        }
        else
        {
            Necklace.SetActive(false);
        }
    }
    public void KiltControls(bool value)
    {
        if (value)
        {
            Kilt.SetActive(true);
            Belt.SetActive(true);
        }
        else
        {
            Kilt.SetActive(false);
            Belt.SetActive(false);
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

    public void OnActivate()
    {
        if (nidaleeAudioSource.isPlaying) return;

        int randomStart = Random.Range(0, StartClips.Length);
        nidaleeAudioSource.PlayOneShot(StartClips[randomStart]);
    }

    public void OnDeactivate()
    {
        if (nidaleeAudioSource.isPlaying) return;

        int randomEnd = Random.Range(0, EndClips.Length);
        nidaleeAudioSource.PlayOneShot(EndClips[randomEnd]);
    }
}

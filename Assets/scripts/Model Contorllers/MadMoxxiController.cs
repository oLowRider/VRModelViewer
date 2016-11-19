using UnityEngine;
using System.Collections;

public class MadMoxxiController : MonoBehaviour {

    public GameObject Skirt;
    [SerializeField]
    bool skirtEnabled;

    public GameObject Belt;
    [SerializeField]
    bool beltEnabled;

    public GameObject Hat;
    [SerializeField]
    bool hatEnabled;

    public GameObject CorsetBoots;
    [SerializeField]
    bool corsetBootsEnabled;

    public GameObject CorsetFull;
    [SerializeField]
    bool corsetFullEnabled;

    public GameObject CorsetLeggings;
    [SerializeField]
    bool corsetLeggingsEnabled;

    public GameObject NudeBoots;
    [SerializeField]
    bool nudeBootsEnabled;

    public GameObject NudeFull;
    [SerializeField]
    bool nudeFullEnabled;

    public GameObject NudeLeggings;
    [SerializeField]
    bool nudeLeggingsEnabled;

    public GameObject Bra;
    [SerializeField]
    bool braEnabled;

    public GameObject FrontSkirt;
    [SerializeField]
    bool frontSkirtEnabled;

    public GameObject Holster;
    [SerializeField]
    bool holsterEnabled;

    public GameObject HolsterBelt;
    [SerializeField]
    bool holsterBeltEnabled;

    public GameObject LegLeftFishnet;
    [SerializeField]
    bool legLeftFishnetEnabled;

    public GameObject LegRightFishnet;
    [SerializeField]
    bool legRightFishnetEnabled;

    public GameObject LegLeftLeggings;
    [SerializeField]
    bool legLeftLeggingsEnabled;

    public GameObject LegRightLeggings;
    [SerializeField]
    bool legRightLeggingsEnabled;

    public GameObject Hair;
    [SerializeField]
    bool hairEnabled;

    public GameObject Reference;
    [SerializeField]
    bool referenceEnabled;

    public Animator MoxxiAnimator;

    public AudioClip[] StartClips, RandomClips, EndClips;
    public AudioSource MoxxiAudioSource;

    void Start ()
    {
        Skirt.SetActive(skirtEnabled);
        Hat.SetActive(hatEnabled);
        CorsetBoots.SetActive(corsetBootsEnabled);
        CorsetFull.SetActive(corsetFullEnabled);
        CorsetLeggings.SetActive(corsetLeggingsEnabled);
        NudeBoots.SetActive(nudeBootsEnabled);
        NudeFull.SetActive(nudeFullEnabled);
        NudeLeggings.SetActive(nudeLeggingsEnabled);
        Bra.SetActive(braEnabled);
        FrontSkirt.SetActive(frontSkirtEnabled);
        Holster.SetActive(holsterEnabled);
        HolsterBelt.SetActive(holsterBeltEnabled);
        LegLeftFishnet.SetActive(legLeftFishnetEnabled);
        LegRightFishnet.SetActive(legRightFishnetEnabled);
        LegLeftLeggings.SetActive(legLeftLeggingsEnabled);
        LegRightLeggings.SetActive(legRightLeggingsEnabled);
        Hair.SetActive(hairEnabled);
        Reference.SetActive(referenceEnabled);
	}

    void Update()
    {
        int randomClips = Random.Range(0, RandomClips.Length);
        if (!MoxxiAudioSource.isPlaying && Time.time >= 90)
        {
            MoxxiAudioSource.PlayOneShot(RandomClips[randomClips]);
        }
    }

    public void MoxxiChangeToPose1(bool value)
    {
        if (value)
        {
            MoxxiAnimator.SetBool("Moxxipose1isTicked", true);
            MoxxiAnimator.SetBool("Moxxipose2isTicked", false);
            MoxxiAnimator.SetBool("Moxxipose3isTicked", false);
        }
    }
    public void MoxxiChangeToPose2(bool value)
    {
        if (value)
        {
            MoxxiAnimator.SetBool("Moxxipose1isTicked", false);
            MoxxiAnimator.SetBool("Moxxipose2isTicked", true);
            MoxxiAnimator.SetBool("Moxxipose3isTicked", false);
        }
    }
    public void MoxxiChangeToPose3(bool value)
    {
        if (value)
        {
            MoxxiAnimator.SetBool("Moxxipose1isTicked", false);
            MoxxiAnimator.SetBool("Moxxipose2isTicked", false);
            MoxxiAnimator.SetBool("Moxxipose3isTicked", true);
        }
    }

    /*Toggle contrls for UI*/
    public void BraControls(bool value)
    {
        if(value)
        {
            braEnabled = true;
            Bra.SetActive(true);
        }
        else
        {
            braEnabled = false;
            Bra.SetActive(false);
        }
    }

    public void ClothesControls(bool value)
    {
        if(value)
        {
            corsetLeggingsEnabled = true;
            CorsetLeggings.SetActive(true);

            legLeftLeggingsEnabled = true;
            LegLeftLeggings.SetActive(true);
            legRightFishnetEnabled = true;
            LegRightFishnet.SetActive(true);

            frontSkirtEnabled = true;
            FrontSkirt.SetActive(true);
            skirtEnabled = true;
            Skirt.SetActive(true);

            beltEnabled = true;
            Belt.SetActive(true);

            nudeFullEnabled = false;
            NudeFull.SetActive(false);
        }
        else
        {
            corsetLeggingsEnabled = false;
            CorsetLeggings.SetActive(false);

            legLeftLeggingsEnabled = false;
            LegLeftLeggings.SetActive(false);
            legRightFishnetEnabled = false;
            LegRightFishnet.SetActive(false);

            frontSkirtEnabled = false;
            FrontSkirt.SetActive(false);
            skirtEnabled = false;
            Skirt.SetActive(false);

            beltEnabled = false;
            Belt.SetActive(false);

            nudeFullEnabled = true;
            NudeFull.SetActive(true);
        }
    }

    public void Belt2Controls(bool value)
    {
        if(value)
        {
            holsterEnabled = true;
            Holster.SetActive(true);
        }
        else
        {
            holsterEnabled = false;
            Holster.SetActive(false);
        }
    }

    public void LeggingsControls(bool value)
    {
        if(value)
        {
            legLeftLeggingsEnabled = true;
            LegLeftLeggings.SetActive(true);

            legRightFishnetEnabled = true;
            LegRightFishnet.SetActive(true);
        }
        else
        {
            legLeftLeggingsEnabled = false;
            LegLeftLeggings.SetActive(false);

            legRightFishnetEnabled = false;
            LegRightFishnet.SetActive(false);
        }
    }

    public void HatControls(bool value)
    {
        if(value)
        {
            hatEnabled = true;
            Hat.SetActive(true);
        }
        else
        {
            hatEnabled = false;
            Hat.SetActive(false);
        }
    }

    public void OnActivate()
    {
        if (MoxxiAudioSource.isPlaying) return;

        int randomStart = Random.Range(0, StartClips.Length);
        MoxxiAudioSource.PlayOneShot(StartClips[randomStart]);
    }

    public void OnDeactivate()
    {
        if (MoxxiAudioSource.isPlaying) return;

        int randomEnd = Random.Range(0, EndClips.Length);
        MoxxiAudioSource.PlayOneShot(EndClips[randomEnd]);
    }
}

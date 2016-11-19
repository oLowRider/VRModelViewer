using UnityEngine;
using System.Collections;

public class ZoeyController : MonoBehaviour {

    public GameObject Jacket;
    [SerializeField]
    bool jacketEnabled;

    public GameObject Pants;
    [SerializeField]
    bool pantsEnabled;

    public GameObject Belt;
    [SerializeField]
    bool beltEnabled;

    public GameObject Shoes;
    [SerializeField]
    bool shoesEnabled;

    public Animator ZoeyAnimator;

    public GameObject ZoeyGunLPose1, ZoeyGunRPose1, ZoeyGunRPose2;

    public AudioClip[] StartClips, RandomClips, EndClips;
    public AudioSource ZoeyAudioSource;

    void Start ()
    {
        Jacket.SetActive(jacketEnabled);
        Pants.SetActive(pantsEnabled);
        Belt.SetActive(beltEnabled);
        Shoes.SetActive(shoesEnabled);

        ZoeyGunLPose1.SetActive(true);
        ZoeyGunRPose1.SetActive(true);
        ZoeyGunRPose2.SetActive(false);
    }

    void Update()
    {
        int randomClips = Random.Range(0, RandomClips.Length);
        if (!ZoeyAudioSource.isPlaying && Time.time >= 90)
        {
            ZoeyAudioSource.PlayOneShot(RandomClips[randomClips]);
        }
    }

    public void ZoeyChangeToPose1(bool value)
    {
        if (value)
        {
            ZoeyAnimator.SetBool("Zoeypose1isTicked", true);
            ZoeyAnimator.SetBool("Zoeypose2isTicked", false);
            ZoeyAnimator.SetBool("Zoeypose3isTicked", false);

            ZoeyGunLPose1.SetActive(true);
            ZoeyGunRPose1.SetActive(true);
            ZoeyGunRPose2.SetActive(false);
        }
    }

    public void ZoeyChangeToPose2(bool value)
    {
        if (value)
        {
            ZoeyAnimator.SetBool("Zoeypose1isTicked", false);
            ZoeyAnimator.SetBool("Zoeypose2isTicked", true);
            ZoeyAnimator.SetBool("Zoeypose3isTicked", false);

            ZoeyGunLPose1.SetActive(false);
            ZoeyGunRPose1.SetActive(false);
            ZoeyGunRPose2.SetActive(true);
        }
    }

    public void ZoeyChangeToPose3(bool value)
    {
        if (value)
        {
            ZoeyAnimator.SetBool("Zoeypose1isTicked", false);
            ZoeyAnimator.SetBool("Zoeypose2isTicked", false);
            ZoeyAnimator.SetBool("Zoeypose3isTicked", true);
        }
    }

    public void JacketControls(bool value)
    {
        if (value)
        {
            jacketEnabled = true;
            Jacket.SetActive(true);
        }
        else
        {
            jacketEnabled = false;
            Jacket.SetActive(false);
        }
    }
    public void PantsControls(bool value)
    {
        if (value)
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
    public void BeltControls(bool value)
    {
        if (value)
        {
            beltEnabled = true;
            Belt.SetActive(true);
        }
        else
        {
            beltEnabled = false;
            Belt.SetActive(false);
        }
    }
    public void ShoesControls(bool value)
    {
        if (value)
        {
            shoesEnabled = true;
            Shoes.SetActive(true);
        }
        else
        {
            shoesEnabled = false;
            Shoes.SetActive(false);
        }
    }

    public void OnActivate()
    {
        if (ZoeyAudioSource.isPlaying) return;

        int randomStart = Random.Range(0, StartClips.Length);
        ZoeyAudioSource.PlayOneShot(StartClips[randomStart]);
    }

    public void OnDeactivate()
    {
        if (ZoeyAudioSource.isPlaying) return;

        int randomEnd = Random.Range(0, EndClips.Length);
        ZoeyAudioSource.PlayOneShot(EndClips[randomEnd]);
    }
}

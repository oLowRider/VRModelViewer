using UnityEngine;
using System.Collections;

public class ElizabethController : MonoBehaviour {

    public GameObject ShortHair, Ponytail, BaSHair;

    public SkinnedMeshRenderer ElizabethBlendShapes;
    public Animator ElizabethAnimator;

    public AudioClip[] StartClips, RandomClips, EndClips;
    public AudioSource elizabethAudioSource;
    float counter = 0;

    void Start ()
    {
	
	}


    void FixedUpdate()
    {
        int randomClips = Random.Range(0, RandomClips.Length);
        if (!elizabethAudioSource.isPlaying)
        {
            counter = counter + 1;
            if (counter > 5400)
            {
                elizabethAudioSource.PlayOneShot(RandomClips[randomClips]);
                counter = 0;
            }
        }
    }

    public void OnActivate()
    {
        if (elizabethAudioSource.isPlaying) return;

        int randomStart = Random.Range(0, StartClips.Length);
        elizabethAudioSource.PlayOneShot(StartClips[randomStart]);
    }

    public void OnDeactivate()
    {
        if (elizabethAudioSource.isPlaying) return;

        int randomEnd = Random.Range(0, EndClips.Length);
        elizabethAudioSource.PlayOneShot(EndClips[randomEnd]);
    }

    public void TracerChangeToPose1(bool value)
    {
        if (value)
        {
            ElizabethAnimator.SetBool("Elizabethpose1isTicked", true);
            ElizabethAnimator.SetBool("Elizabethpose2isTicked", false);
            ElizabethAnimator.SetBool("Elizabethpose3isTicked", false);

            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
    public void TracerChangeToPose2(bool value)
    {
        if (value)
        {
            ElizabethAnimator.SetBool("Elizabethpose1isTicked", false);
            ElizabethAnimator.SetBool("Elizabethpose2isTicked", true);
            ElizabethAnimator.SetBool("Elizabethpose3isTicked", false);

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    public void TracerChangeToPose3(bool value)
    {
        if (value)
        {
            ElizabethAnimator.SetBool("Elizabethpose1isTicked", false);
            ElizabethAnimator.SetBool("Elizabethpose2isTicked", false);
            ElizabethAnimator.SetBool("Elizabethpose3isTicked", true);

            transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        }
    }

    public void ShortHairControls(bool value)
    {
        if (value)
        {
            ShortHair.SetActive(true);
            Ponytail.SetActive(false);
            BaSHair.SetActive(false);
        }
        else
        {
            ShortHair.SetActive(false);
        }
    }
    public void PonytailControls(bool value)
    {
        if (value)
        {
            ShortHair.SetActive(false);
            Ponytail.SetActive(true);
            BaSHair.SetActive(false);
        }
        else
        {
            Ponytail.SetActive(false);
        }
    }
    public void BaSHairControls(bool value)
    {
        if (value)
        {
            ShortHair.SetActive(false);
            Ponytail.SetActive(false);
            BaSHair.SetActive(true);
        }
        else
        {
            BaSHair.SetActive(false);
        }
    }


}
